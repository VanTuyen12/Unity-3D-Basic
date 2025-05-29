using System;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;

public class PlayerCtrl : SaiSingleton<PlayerCtrl>
{
  [SerializeField] vThirdPersonController thirdPersonCtrl;
  public vThirdPersonController ThirdPersonCtrl => thirdPersonCtrl;
  
  [SerializeField] vThirdPersonCamera thirdPersonCamera;
  public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;
  
  [SerializeField] CrosshairPointer crosshairPointer;
  public CrosshairPointer CrosshairPointer => crosshairPointer;
  
  [SerializeField] protected Rig aimingRig;
  public Rig AimingRig => aimingRig;
  
  [SerializeField] protected Animator animator;
  public Animator Animator => animator;
  
  [SerializeField] protected Weapons weapons;
  public Weapons Weapons => weapons;

  [SerializeField] protected LevelAbstract level;
  public LevelAbstract Level => level;
  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonController();  
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadAimingRig();
        this.LoadAnimator();
        this.LoadWeapons();
        this.LoadLevel();
    }
    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<LevelAbstract>();
        Debug.Log(transform.name + " :LoadLevel ",gameObject);
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
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.2f;
        this.thirdPersonCamera.height = 1.3f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
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
       
        Debug.Log(transform.name + " :LoadAimingRig ",gameObject);
    }
    
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
       
        Debug.Log(transform.name + " :LoadAnimator ",gameObject);
    }
    
    protected virtual void LoadWeapons()
    {
        if (this.weapons != null) return;
        this.weapons = GetComponentInChildren<Weapons>();
       
        Debug.Log(transform.name + " :LoadWeapons ",gameObject);
    }
}
