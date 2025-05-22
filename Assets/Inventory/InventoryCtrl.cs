using System.Collections.Generic;
using Inventory;
using UnityEngine;

public abstract class InventoryCtrl : SaiMonoBehaviour
{
   //quan ly cac vat pham va ruong
   
   protected List<ItemInventory> items = new();
   
   public abstract InvCodeName GetName();

   public virtual void AddItem(ItemInventory item)//Them vat pham vao trong kho do
   {
      ItemInventory itemExist = FindItem(item.itemProfile.itemCode);//Lay vat pham do ra
      if (!item.itemProfile.isStackable || itemExist == null)
      {
         items.Add(item);
         return;
      }
      itemExist.itemCount += item.itemCount;//co vat pham do r thi cong vs nhau
   }

   public virtual ItemInventory FindItem(ItemCode itemCode)//Ktra vat pham da co trong kho chua
   {
      foreach (ItemInventory itemInventory in items)
      {
         if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
      }
      
      return null;
   }
}
