using System;
using System.Collections;
using System.Collections.Generic;
using Script;
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
                nearest = enemyCtrl;
            }
        }
    }

    protected virtual bool CanSeeTarget(EnemyCtrl target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;
        
        if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask))
        {
            Vector3 directionToCollider = hitInfo.point - transform.position;
            float distanceToCollider= directionToCollider.magnitude;
            
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