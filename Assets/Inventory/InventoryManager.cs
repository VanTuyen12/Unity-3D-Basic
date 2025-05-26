using System.Collections.Generic;
using Inventory;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        this.LoadItemProfiles();
    }

    protected override void Start()
    {
        base.Start();
        /*this.AddTestItems(20);//Ham test
        this.AddTestGold(100);
        Invoke(nameof(this.AddTestItemDelay),5f);*/
    }

    protected virtual void AddTestItemDelay()
    {
        //this.AddTestItems(8);//Ham test
    }
    protected virtual void AddTestGold(int count)//Ham test add do
    {
        /*
        InventoryCtrl inventoryCtrl = GetByCodeName(InvCodeName.Monies); //Chon vi tri kho do

        ItemInventory gold = new (); //tao mon do
        gold.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        gold.itemName = gold.itemProfile.itemName;
        gold.itemCount = count;
        inventoryCtrl.AddItem(gold); //them mon do vao kho do
        */

        /*ItemInventory item2 = new ();
        item2.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        item2.itemName = item2.itemProfile.itemName;
        item2.itemCount = 22;
        inventoryCtrl.AddItem(item2);*/
    }
    /*protected virtual void AddTestItems(int count)//Ham test add do
    {
        InventoryCtrl items = GetByCodeName(InvCodeName.Items); //Chon vi tri kho do
        
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new(); //tao mon do
            wand.itemProfile = this.GetProfileByCode(ItemCode.Wand);
            wand.itemName = wand.itemProfile.itemName;//ten mon do
            wand.itemCount = i;//giatri
            items.AddItem(wand); //them mon do vao kho do
        }
    }*/

    
    protected virtual void LoadInventories()
    {
        if(inventories.Count > 0) return;
        
        foreach (Transform Child in transform)
        {
            InventoryCtrl inventoryCtrl = Child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            inventories.Add(inventoryCtrl);
        }
        
    }
    
    protected virtual void LoadItemProfiles()
    {
        if (this.itemProfiles.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
    }
    public virtual InventoryCtrl GetByCodeName(InvCodeName inventoryName)
    {
        foreach (InventoryCtrl inventory in inventories)
        {
            if(inventory.GetName() == inventoryName) return inventory;//ktra kho do chuyen do co dung chua
        }
        return null;
    }
    
    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCode)
    {
        foreach (ItemProfileSO itemProfile in itemProfiles)
        {
            if(itemProfile.itemCode == itemCode) return itemProfile;//ktra item do co trong kho chua
        }
        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return GetByCodeName(InvCodeName.Monies);
    }
    
    public virtual InventoryCtrl Items()
    {
        return GetByCodeName(InvCodeName.Items);
    }
}
