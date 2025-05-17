
public class PlayerAiming : PlayerAbstract
{
      float closeLookDistance = 0.6f;
      float farLookDistance = 1.3f;
   protected virtual void Update()
   {
      this.Aiming();
   }

   protected virtual void Aiming()
   {
      if (InputManager.Instance.IsRightClick()) this.LoakClose();
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
