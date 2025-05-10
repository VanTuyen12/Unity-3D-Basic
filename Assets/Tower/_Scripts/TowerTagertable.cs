using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TowerTagertable : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;

        Debug.Log(transform.name + ": LoadSphereCollider() ", gameObject);
    }
}