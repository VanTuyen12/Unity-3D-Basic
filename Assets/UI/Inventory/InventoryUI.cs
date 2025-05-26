using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    bool IsShow => isShow;

    [SerializeField] protected Transform showHide;
    
    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    protected List<BtnItemInventory> btnItems = new();

    protected virtual void FixedUpdate()
    {
        this.ItemsUpdating();
    }

    protected virtual void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }
    protected override void Start()
    {
        base.Start();
        this.Show();
        this.HideDefaultItemInventory();
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
        this.LoadShowHide();
    }


    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();

        Debug.Log(transform.name + " :LoadBtnItemInventory ", gameObject);
    }
    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");

        Debug.Log(transform.name + " :LoadShowHide ", gameObject);
    }

    public virtual void Show()
    {
        showHide.gameObject.SetActive(true);
        this.isShow = true;
    }

    public virtual void Hide()
    {
        showHide.gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) Hide();
        else Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    protected virtual void ItemsUpdating()
    {
        if(this.isShow == false) return;
        
        InventoryCtrl itemInvCtr = InventoryManager.Instance.Items();

        foreach (ItemInventory itemInventory in itemInvCtr.Items)
        {
            BtnItemInventory newBtnItem = this.GetExistItem(itemInventory);

            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(this.defaultItemInventoryUI); //tao ra ban sao
                newBtnItem.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.transform.localScale = new Vector3(1, 1, 1);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.itemName + " - " + itemInventory.ItemId;
                this.btnItems.Add(newBtnItem);
            }
        }
    }

    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory itemInvUI in this.btnItems)
        {
            if (itemInvUI.ItemInventory.ItemId == itemInventory.ItemId) return itemInvUI;
            
        }

        return null;
    }

    protected virtual void HotkeyToogleInventory()
    {
        if (InputHotkey.Instance.IsToogleInventoryUI) this.Toggle();
        
    }
}