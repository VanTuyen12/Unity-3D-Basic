using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ItemInventory
{
    
    public ItemProfileSO ItemProfile => itemProfile;
    
    
    //ten cac vat pham de them vao rung
    public int ItemId;
    public string itemName;
    public ItemProfileSO itemProfile;
    public int itemCount;
    
    public virtual bool Deduct(int number)//Bot sl 1 item
    {
        if (!this.CanDeduct(number)) return false;
        this.itemCount -= number;
        return true;
    }
    
    public virtual bool CanDeduct(int number)//them sl 1 item
    {
        return this.itemCount >= number;
    }
}
