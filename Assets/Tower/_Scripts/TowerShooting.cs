using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerShooting : TowerAbstract
{
    [SerializeField]protected EnemyCtrl target;
    [SerializeField] private float ShootSpeed = 1f;
    [SerializeField] private float TargetLoadSpeed = 1f;
    [SerializeField] private int currentFirePoint = 0;
    [SerializeField]protected float rotationSpeed = 2f;
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
    
    protected virtual void Shooting()//Ktra enemy co trong pham vi cau shootgun hay k
    { 
        Invoke(nameof(this.Shooting),this.ShootSpeed);
        if(this.target == null) return;

        FirePoint firePoint = this.GetFirePoint();// Lấy Point nào ?
        Bullet newBullet = this.towerCtrl.BulletSpanwer.Spawn(this.towerCtrl.Bullet,firePoint.transform.position);//Spawn đạn theo vị trí của Point
        
        Vector3 rotatorDirection = this.towerCtrl.Rotator.transform.forward;//Lấy hướng cu Rotator
        newBullet.transform.forward = rotatorDirection;//gán hướng vtri vien dan bay theo huong quay của Rotator
        
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
       FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];
       
       currentFirePoint++;
       if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;
       
       return firePoint;
    }
}
