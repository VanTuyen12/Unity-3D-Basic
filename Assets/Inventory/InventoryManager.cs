using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    
    [SerializeField] protected List<ItemProfileSO> itemProfile;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }

    protected override void Start()
    {
        base.Start();
        //this.AddTestItems();Ham test
    }

    protected virtual void AddTestItems()//Ham test add do
    {
       

        InventoryCtrl inventoryCtrl = GetByName(InvCodeName.Monies); //Chon vi tri kho do

        ItemInventory gold = new ItemInventory(); //tao mon do
        gold.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        gold.itemCount = 11;
        inventoryCtrl.AddItem(gold); //them mon do vao kho do

        ItemInventory item2 = new ItemInventory();
        item2.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        item2.itemCount = 22;
        inventoryCtrl.AddItem(item2);

        InventoryCtrl inventoryCtrl_Wand = GetByName(InvCodeName.Items); //Chon vi tri kho do

        ItemInventory wand1 = new ItemInventory(); //tao mon do
        wand1.itemProfile = this.GetProfileByCode(ItemCode.Wand);
        wand1.itemCount = 1;
        inventoryCtrl_Wand.AddItem(wand1); //them mon do vao kho do

        ItemInventory wand2 = new ItemInventory();
        wand2.itemProfile = this.GetProfileByCode(ItemCode.Wand);
        wand2.itemCount = 9;
        inventoryCtrl_Wand.AddItem(wand2);
        
    }

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

    public virtual InventoryCtrl GetByName(InvCodeName inventoryName)
    {
        foreach (InventoryCtrl inventory in inventories)
        {
            if(inventory.GetName() == inventoryName) return inventory;//ktra kho do chuyen do co dung chua
        }
        return null;
    }
    
    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCode)
    {
        foreach (ItemProfileSO itemProfile in itemProfile)
        {
            if(itemProfile.itemCode == itemCode) return itemProfile;//ktra item do co trong kho chua
        }
        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return GetByName(InvCodeName.Monies);
    }
    
    public virtual InventoryCtrl Items()
    {
        return GetByName(InvCodeName.Items);
    }
}
