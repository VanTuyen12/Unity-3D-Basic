using System;
using TMPro;
using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    [SerializeField]protected TextMeshProUGUI txtItemName;
    [SerializeField]protected TextMeshProUGUI txtItemCount;
    [SerializeField]protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCount();
        this.LoadItemName();
    }

    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    public override void OnClick()
    {
       Debug.Log("btnItemInventory");
    }
    
    protected virtual void LoadItemCount()
    {
        if(txtItemCount !=null ) return;
        this.txtItemCount = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
        
        Debug.Log("LoadTextCount");
    }
    
    protected virtual void LoadItemName()
    {
        if(txtItemName != null ) return;
        this.txtItemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        
        Debug.Log("LoadTextName");
    }

    protected virtual void ItemUpdating()
    {
        if (itemInventory.itemCount == 0)
        {
            Destroy(gameObject);
        }
        this.txtItemName.text = itemInventory.GetItemName();
        this.txtItemCount.text = itemInventory.itemCount.ToString();
    }
}
