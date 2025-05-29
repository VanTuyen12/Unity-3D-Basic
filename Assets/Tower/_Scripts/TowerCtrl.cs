using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    
    [SerializeField] protected TowerTargeting towerTargeting; 
    public TowerTargeting TowerTargeting => towerTargeting;
    
    [SerializeField] protected BulletSpanwer bulletSpanwer;
    public BulletSpanwer BulletSpanwer => bulletSpanwer;
    
    
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;
    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;
    
    [SerializeField] protected LevelAbstract level;
    public LevelAbstract Level => level;
    
    [SerializeField] protected List<FirePoint> firePoints;
    public List<FirePoint> FirePoints => firePoints;
    
    

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpanwer();
        this.LoadBullet();
        this.LoadFirePoints();
        this.LoadTowerShootings();
        this.LoadLevelAbstract();
    }

    protected virtual void LoadLevelAbstract()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<LevelAbstract>();
        Debug.Log(transform.name + " LoadLevelAbstract(): ", gameObject);
    }
    protected virtual void LoadTowerShootings()
    {
        if (this.towerShooting != null) return;
        this.towerShooting = GetComponentInChildren<TowerShooting>();
        Debug.Log(transform.name + " LoadTowerShootings(): ", gameObject);
    }
    protected virtual void LoadBullet()
    {
       if(this.bullet != null) return;
       bullet = transform.GetComponentInChildren<Bullet>();
       
       Debug.Log(transform.name + ":LoadBullet ", gameObject);
    }

    protected virtual void LoadBulletSpanwer()
    {
        if(bulletSpanwer != null) return;
        this.bulletSpanwer = FindAnyObjectByType<BulletSpanwer>();
        
        Debug.Log(transform.name + " :LoadBulletSpanwer ", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = model.Find("Rotator");
        Debug.Log(transform.name + " LoadModel(): ", gameObject);
    }
    
    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        Debug.Log(transform.name + " LoadTowerTargeting(): ", gameObject);
    }
    
    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>(); // Tra ve mang ds cua FirePoint
        this.firePoints = new List<FirePoint>(points);//them ds FirePoint trong mang tra ve vao List
        Debug.Log(transform.name + " LoadFirePoints(): ", gameObject);
    }
    
    protected virtual void HidePrefabs()
    {
       this.bullet.gameObject.SetActive(false);
    }
}