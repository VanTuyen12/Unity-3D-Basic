using System.Collections.Generic;
using Inventory;
using UnityEngine;


   public abstract class InventoryCtrl : SaiMonoBehaviour
   {
      //quan ly cac vat pham va ruong
   
      [SerializeField]protected List<ItemInventory> items = new();
      public List<ItemInventory> Items => items;
   
      public abstract InvCodeName GetName();

      public virtual void AddItem(ItemInventory item)//Them vat pham vao trong kho do
      {
      
         ItemInventory itemExist = FindItem(item.itemProfile.itemCode);//Lay vat pham do ra
         if (!item.itemProfile.isStackable || itemExist == null)
         {
            item.ItemId = Random.Range(0, 9999999);
            items.Add(item);
            return;
         }
         itemExist.itemCount += item.itemCount;//co vat pham do r thi cong vs nhau
      }
   
   
      public virtual bool RemoveItem(ItemInventory item)
      {
         ItemInventory itemExist = this.FindItemNotEmpty(item.ItemProfile.itemCode);
         if (itemExist == null) return false;
         if (!itemExist.CanDeduct(item.itemCount)) return false;
         itemExist.Deduct(item.itemCount);
         if (itemExist.itemCount == 0) this.items.Remove(itemExist);
         return true;
      }
   
      public virtual ItemInventory FindItem(ItemCode itemCode)//Ktra vat pham da co trong kho chua
      {
         foreach (ItemInventory itemInventory in items)
         {
            if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
         }
      
         return null;
      }
   
      public virtual ItemInventory FindItemNotEmpty(ItemCode itemCode)
      {
         foreach (ItemInventory itemInventory in this.items)
         {
            if (itemInventory.ItemProfile.itemCode != itemCode) continue;
            if (itemInventory.itemCount > 0) return itemInventory;
         }

         return null;
      }
   }

