using UnityEngine;

public class BtnCloseInventory : ButtonAbstract
{
    public virtual void CloseInventoryUI()
    {
        InventoryUI.Instance.Hide();
    }

    public override void OnClick()
    {
        CloseInventoryUI();
    }
}
