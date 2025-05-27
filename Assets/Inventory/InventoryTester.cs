using com.cyborgAssets.inspectorButtonPro;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class InventoryTester : SaiMonoBehaviour
{
    
    
    protected override void Start()
    {
        base.Start();
        this.AddTestItems(ItemCode.Gold, 1000);
    }

    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.AddItem(itemCode, 1);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.RemoveItem(itemCode, 1);
        }
    }
    /*[ProButton]
    public virtual void AddTestGold(int count)
    {
            InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(InvCodeName.Currency); //Chon vi tri kho do
            ItemInventory gold = new(); //tao mon do
            gold.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
            gold.SetName(gold.itemProfile.itemName);  
            gold.itemCount = count;
            inventoryCtrl.AddItem(gold);
        
        //them mon do vao kho do
    }
    
    [ProButton]
    public virtual void RemoveTestGold( int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(InvCodeName.Currency); //Chon vi tri kho do
        
            ItemInventory Gold = new(); //tao mon do
            Gold.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
            Gold.SetName(Gold.itemProfile.itemName); //ten mon do
            Gold.itemCount = count;//giatri
            inventoryCtrl.RemoveItem(Gold); //them mon do vao kho do
        
    }
    
    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByCodeName(InvCodeName.Items); //Chon vi tri kho do
        
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new(); //tao mon do
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            wand.SetName(wand.itemProfile.itemName);//ten mon do
            wand.itemCount = 1;//giatri
            items.AddItem(wand); //them mon do vao kho do
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByCodeName(InvCodeName.Items); //Chon vi tri kho do
        
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new(); //tao mon do
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            wand.SetName(wand.itemProfile.itemName);//ten mon do
            wand.itemCount = 1;//giatri
            items.RemoveItem(wand); //them mon do vao kho do
        }
    }*/
}