using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigib;
    
    [SerializeField] protected EnemyCtrl nearest;
    public EnemyCtrl NearCtrl => nearest;
    
    [SerializeField] protected LayerMask obstacleLayerMask;
    [SerializeField] protected List<EnemyCtrl> enemies = new();

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
        this.RemoveDeadEnemy();
    }
    
    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.AddEnemy(collider);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveEnemy(collider);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLES) return;
        EnemyCtrl enemyCtrl = collider.transform.parent.GetComponent<EnemyCtrl>();
        if(enemyCtrl.EnenyDamageRecever.IsDead()) return;
        
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (collider.transform.parent.name == enemyCtrl.name)
            {
                if(enemyCtrl == this.nearest) this.nearest = null;
                
                enemies.Remove(enemyCtrl);
                return;
            }
        }
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigib != null) return;
        this.rigib = this.GetComponent<Rigidbody>();
        this.rigib.useGravity = false;

        //Debug.Log(transform.name + ": LoadRigidbody() ", gameObject);
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 13f;

        //Debug.Log(transform.name + ": LoadSphereCollider() ", gameObject);
    }

    protected virtual void FindNearest()//Mtieu gan nhat
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDisTance;
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (!this.CanSeeTarget(enemyCtrl)) continue;
                
            enemyDisTance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDisTance < nearestDistance)
            {
                nearestDistance = enemyDisTance;
                this.nearest = enemyCtrl;
            }
        }
    }

    protected virtual bool CanSeeTarget(EnemyCtrl target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position; //Tim vector co huong tu enemy den scripts dc gan
        float distanceToTarget = directionToTarget.magnitude;//Do dai cua vector do
        #region Giai thich các doi tuong trong if
        //    - Physics.Raycast(): Một hàm của Unity dùng để bắn một tia ảo từ một điểm, theo một hướng,
        //      và xem nó có chạm vào vật nào không.
        //    - transform.position: Điểm bắt đầu của tia (vị trí của đối tượng hiện tại).
        //    - directionToTarget: Hướng của tia. Tia sẽ được bắn theo hướng đã tính ở trên.
        //    - out RaycastHit hitInfo: Nếu tia chạm vào một vật nào đó, thông tin về điểm va chạm
        //      (như vị trí va chạm, đối tượng bị chạm phải) sẽ được lưu vào biến 'hitInfo'.
        //      Từ khóa 'out' nghĩa là hàm Raycast sẽ gán giá trị cho biến này.
        //    - distanceToTarget: Độ dài tối đa của tia. Tia sẽ chỉ kiểm tra va chạm trong phạm vi khoảng cách này.
        //      Điều này quan trọng vì chúng ta chỉ quan tâm đến vật cản nằm GIỮA đối tượng và mục tiêu.
        //    - obstacleLayerMask: Đây là một LayerMask, dùng để lọc các đối tượng mà tia Raycast sẽ tương tác.
        //      Nghĩa là, tia sẽ chỉ phát hiện va chạm với các đối tượng nằm trên các layer được chọn trong obstacleLayerMask.
        #endregion
        if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask))
        {
            //NẾU tia Raycast chạm vào một vật cản (thuộc obstacleLayerMask) TRƯỚC KHI đến được mục tiêu:
            Vector3 directionToCollider = hitInfo.point - transform.position;//Vị trí chính xác mà tia Raycast chạm vào vật cản.
            float distanceToCollider= directionToCollider.magnitude; // Thực ra, distanceToCollider sẽ bằng hitInfo.distance(kc tia laze đến vật nó chạm vào)
            
            //Đường này đi từ vị trí hiện tại, theo hướng tới mục tiêu, và có độ dài bằng khoảng cách tới mục tiêu.
            //Vẽ 1 đg kẻ để nhìn thấy trên Scene
            Debug.DrawRay(transform.position, directionToCollider.normalized * distanceToCollider, Color.red);
            return false;
        }
        
        Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
        return true;
    }
    
    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (enemyCtrl.EnenyDamageRecever.IsDead())
            {
                if(enemyCtrl == this.nearest) this.nearest = null;
                
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}