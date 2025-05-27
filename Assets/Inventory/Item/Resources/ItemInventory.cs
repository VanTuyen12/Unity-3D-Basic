using System;
using Inventory;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ItemInventory
{
    //ten cac vat pham de them vao rung
    protected int itemId;
    public int ItemID => itemId;
    
    public ItemProfileSO itemProfile;
    public ItemProfileSO ItemProfile => itemProfile;
    
    [SerializeField] protected string itemName;
    
    public int itemCount;
    
    public ItemInventory(ItemProfileSO itemProfile, int itemCount)
    {
        this.itemProfile = itemProfile;
        this.itemCount = itemCount;
        this.itemName = this.itemProfile.itemName;
    }
    
    public virtual void SetId(int id)
    {
        this.itemId = id;
    }
    public virtual void SetName(string name)
    {
        this.itemName = name;
    }
    public virtual string GetItemName()
    {
        if (this.itemName == null || this.itemName == "") return this.itemProfile.itemName;
        return this.itemName;
    }
    
    /*public virtual bool Deduct(int number)//Bot sl 1 item
    {
        if (!this.CanDeduct(number)) return false;
        this.itemCount -= number;
        return true;
    }*/
    
    public virtual bool Deduct(int number)
    {
        if (this.itemCount < number) return false;
        this.itemCount -= number;
        return true;
    }
    
    public virtual bool CanDeduct(int number)//them sl 1 item
    {
        return this.itemCount >= number;
    }
}
