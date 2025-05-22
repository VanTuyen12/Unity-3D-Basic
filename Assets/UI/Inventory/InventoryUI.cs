using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    bool IsShow => isShow;
    protected override void Start()
    {
        base.Start();
        this.Show();
        //this.Hide();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        this.isShow = true;
    }
        
    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) Hide();
        else Show();
    }
}
