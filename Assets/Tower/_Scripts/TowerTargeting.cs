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
    
    [SerializeField] protected List<EnemyCtrl> enemies = new();

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
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
        this.enemies.Add(enemyCtrl);

        //Debug.Log("AddEnemy: " + collider.name);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        //Debug.Log("RemoveEnemy: " + collider.transform);

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
        this.sphereCollider.radius = 9f;

        //Debug.Log(transform.name + ": LoadSphereCollider() ", gameObject);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDisTance;
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            enemyDisTance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDisTance < nearestDistance)
            {
                nearestDistance = enemyDisTance;
                nearest = enemyCtrl;
            }
        }
    }
}