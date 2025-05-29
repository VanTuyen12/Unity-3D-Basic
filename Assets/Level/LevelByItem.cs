using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
   [SerializeField] protected ItemInventory playerExp;
   protected override int GetCurrentLevel()
   {
      if(GetPlayerExp() == null) return 0;//neu item chua co thi rt;
      return GetPlayerExp().itemCount;//tra ve so exp co
   }

   protected override bool DeductExp(int exp)//ktra len lv thanh cong hay k
   {
      return this.GetPlayerExp().Deduct(exp);
   }

   // ReSharper disable Unity.PerformanceAnalysis
   protected virtual ItemInventory GetPlayerExp()//Lay lien ket den item PlayerExp
   {
      //Debug.Log("GetPlayerExp");
      if (playerExp == null || this.playerExp.ItemID == 0) this.playerExp = InventoryManager.Instance.Monies().FindItem(ItemCode.PlayerExp);
      return this.playerExp;
   }
}
