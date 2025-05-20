
using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
   [SerializeField] protected bool isAlwayAiming = false;
    protected  float closeLookDistance = 0.6f;
    protected  float farLookDistance = 1.3f;
   protected virtual void FixedUpdate()
   {
      this.Aiming();
   }

   protected virtual void Aiming()
   {
      if (this.isAlwayAiming ||InputManager.Instance.IsAiming()) this.LoakClose();
      else this.LoakFar();
   }

   protected virtual void LoakClose()
   {
      this.playerCtrl.ThirdPersonCamera.defaultDistance = this.closeLookDistance;
      
      CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;
      this.playerCtrl.ThirdPersonCtrl.RotateToPosition(crosshairPointer.transform.position);//quay mat position click mouse right
      
      this.playerCtrl.ThirdPersonCtrl.isSprinting = false;
      
      this.playerCtrl.AimingRig.weight = 1;
   }
   
   protected virtual void LoakFar()
   {
      this.playerCtrl.ThirdPersonCamera.defaultDistance = this.farLookDistance;
      this.playerCtrl.AimingRig.weight = 0;
   }
}
