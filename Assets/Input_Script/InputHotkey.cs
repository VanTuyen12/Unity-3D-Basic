using UnityEngine;

public class InputHotkey : SaiSingleton<InputHotkey>
{
    [SerializeField] protected bool isToogleInventoryUI = false;

    public bool IsToogleInventoryUI => isToogleInventoryUI;

    protected virtual void Update()
    {
        this.OpenInventory();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }
}
