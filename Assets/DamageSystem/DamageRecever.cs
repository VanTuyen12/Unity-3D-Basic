using System;
using UnityEngine;

public abstract class DamageRecever : SaiMonoBehaviour
{
   protected int maxHP = 10;
   public int MaxHP => maxHP;
   
   protected int currrentHP = 10;
   public int CurrentHP => currrentHP;
   
   protected bool isDead = false;
   [SerializeField] protected bool isImmotal = false;

   protected virtual void OnEnable()//Hàm được gọi khi Object được kích hoạt lại
   {
      this.OnReborn();
   }
   

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

   public virtual bool IsDead()
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
   
   protected virtual void OnReborn() 
   {
     this.currrentHP = this.maxHP;
   }
}
