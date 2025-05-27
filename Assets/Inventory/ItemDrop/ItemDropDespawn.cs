using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
   public override void DoDespawn()
   {
        ItemDropCtrl itemDropCtrl = (ItemDropCtrl)this.parent;
        InventoryManager.Instance.AddItem(itemDropCtrl.ItemCode,itemDropCtrl.ItemCount);
        base.DoDespawn();
      
   }
}
