using UnityEngine;

public abstract class DamageRecever : SaiMonoBehaviour
{
   protected int maxHP = 10;
   protected int currrentHP = 10;
   protected bool isDead = false;
   [SerializeField] protected bool isImmotal = false;
   public virtual int Deduct(int hp)
   {
      
      if(isImmotal) this.currrentHP -= hp;
      
      if ( this.IsDead()) {
         this.OnDead();
      }
      else {
         this.OnHurt();
      }
      
      if (currrentHP < 0 ) this.currrentHP = 0;
      return currrentHP;
   }

   protected virtual bool IsDead()
   {
      return this.isDead = this.currrentHP <= 0;
   }
   
   protected virtual void OnDead() 
   {
      //For Override
   }
   
   protected virtual void OnHurt() 
   {
      //For Override
   }
}
