using Inventory;
using UnityEngine;

public class InventoryItems : InventoryCtrl
{
    //Chua vat pham
    public override InvCodeName GetName()
    {
        return InvCodeName.Items;
    }
}
