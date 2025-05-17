using System;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;

public class PlayerCtrl : SaiMonoBehaviour
{
  [SerializeField] vThirdPersonController thirdPersonCtrl;
  public vThirdPersonController ThirdPersonCtrl => thirdPersonCtrl;
  
  [SerializeField] vThirdPersonCamera thirdPersonCamera;
  public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;
  
  [SerializeField] CrosshairPointer crosshairPointer;
  public CrosshairPointer CrosshairPointer => crosshairPointer;
  
  [SerializeField] protected Rig aimingRig;
  public Rig AimingRig => aimingRig;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonController();  
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadAimingRig();
    }

    protected virtual void LoadThirdPersonController()
    {
       if (this.ThirdPersonCtrl != null) return;
       this.thirdPersonCtrl = this.GetComponent<vThirdPersonController>();
       
       Debug.Log(transform.name + " :LoadThirdPersonControlle ",gameObject);
    }
    
    
    
    protected virtual void LoadThirdPersonCamera()
    {
        if (this.thirdPersonCamera != null) return;
        this.thirdPersonCamera = FindAnyObjectByType<vThirdPersonCamera>();
       
        Debug.Log(transform.name + " :LoadThirdPersonCamera ",gameObject);
    }
    
    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = transform.GetComponentInChildren<CrosshairPointer>();
       
        Debug.Log(transform.name + " :LoadCrosshairPointer ",gameObject);
    }
    
    protected virtual void LoadAimingRig()
    {
        if (this.aimingRig != null) return;
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
       
        Debug.Log(transform.name + " :LoadThirdPersonControlle ",gameObject);
    }
}
