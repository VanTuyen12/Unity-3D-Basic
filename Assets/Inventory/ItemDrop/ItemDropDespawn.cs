using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
   public override void DoDespawn()
   {
        ItemDropCtrl itemDropCtrl = (ItemDropCtrl)this.parent;
       
        ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemDropCtrl.ItemCode);//+ Count khi quai die
        item.itemCount = 1;
        InventoryManager.Instance.GetByCodeName(itemDropCtrl.InvCodeName).AddItem(item);
        base.DoDespawn();
      
   }
}
