using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerShooting : TowerAbstract
{
    [SerializeField]protected EnemyCtrl target;
    
    [SerializeField] protected float ShootSpeed = 0.2f;
    [SerializeField] protected float TargetLoadSpeed = 0.2f;
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField]protected float rotationSpeed = 2f;
    [SerializeField]protected int killCount = 0;
    public int KillCount => killCount;
    [SerializeField]protected int totalKill = 0;
    public int TotalKill => totalKill;
    
    [SerializeField]protected EffectSpawner effectSpawner;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading),this.TargetLoadSpeed);
        Invoke(nameof(this.Shooting),this.ShootSpeed);
        
    }

    protected void FixedUpdate()
    {
    
        this.Looking();
        //this.TargetLoading();
        this.IsTargetDead();
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading),this.TargetLoadSpeed);
        this.target = this.towerCtrl.TowerTargeting.NearCtrl;
    }

    protected virtual void Looking()
    {
        if(this.target == null) return;

        //Tính toán vector hướng từ tháp (Rotator) đến mục tiêu.
        Vector3 directionToTarget = this.target.TowerTagertable.transform.position - this.towerCtrl.Rotator.position;
        
        //RotateTowards: xoay dần một vector hướng hiện tại đến một vector hướng đích
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,         // Hướng hiện tại của tháp
            directionToTarget,                     // Hướng cần quay tới
            rotationSpeed * Time.fixedDeltaTime,    // Góc tối đa có thể quay mỗi frame (radian)
            0.0f                                 // Không thay đổi độ dài vector
        );
        
        //Áp dụng hướng mới cho bộ quay tính ra góc để quay r gán cho Rotator để nó quay
        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
        
        //this.towerCtrl.Rotator.LookAt(this.target.TowerTagertable.transform.position);//Nhìn về vtr 1 gameObject
    }
    //code cu
    /*protected virtual void Shooting()//Ktra enemy co trong pham vi cau shootgun hay k
    { 
        Invoke(nameof(this.Shooting),this.ShootSpeed);
        if(this.target == null) return;

        FirePoint firePoint = this.GetFirePoint();// Lấy Point nào ?
        Bullet newBullet = this.towerCtrl.BulletSpanwer.Spawn(this.towerCtrl.Bullet,firePoint.transform.position);//Spawn đạn theo vị trí của Point
        
        Vector3 rotatorDirection = this.towerCtrl.Rotator.transform.forward;//Lấy hướng cu Rotator
        newBullet.transform.forward = rotatorDirection;//gán hướng vtri vien dan bay theo huong quay của Rotator
        
        newBullet.gameObject.SetActive(true);
    }*/

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting),ShootSpeed + Random.Range(-0.1f,0.1f));  
        if(target == null) return;
        
        FirePoint firePoint = GetFirePoint();//Lay vitri point
        Vector3 rotatorDirection = towerCtrl.Rotator.transform.forward;//lay Huong Rotator xoay cua trc z

        this.SpawnBullet(firePoint.transform.position, rotatorDirection);//Spawn vien dan theo huong
        this.SpawnMuzzle(firePoint.transform.position, rotatorDirection);//Spawn vien dan theo huong
    }
    
    protected virtual FirePoint GetFirePoint()//Lay vtri point
    {
       FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];
       
       currentFirePoint++;
       if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;
       
       return firePoint;
    }
    protected virtual void SpawnBullet(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        Bullet newBullet = this.towerCtrl.BulletSpanwer.Spawn(this.towerCtrl.Bullet,spawnPoint);//Spawn đạn theo vị trí của Point
        newBullet.transform.forward = rotatorDirection;//gán hướng vtri vien dan bay theo huong quay của Rotator
        newBullet.gameObject.SetActive(true);
    }
    
    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        
        EffectCtrl effect = EffectSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName("Muzzle1");//Lay doi tuong can spawn
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(effect, spawnPoint);//spawn
        newEffect.transform.forward = rotatorDirection;//quay doi tuong theo truc R
        newEffect.gameObject.SetActive(true);
    }
    
    protected virtual bool IsTargetDead()
    {
        if(this.target == null) return true;//ko co muc tieu coi nhu die r
        if(!target.EnenyDamageRecever.IsDead()) return false;
        killCount++;
        totalKill++;
        target = null;
        
        return true;
    }

    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        killCount -= count;
        return true;
    }
}
