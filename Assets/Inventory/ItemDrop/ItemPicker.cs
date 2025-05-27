using System;
using Inventory;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPicker : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0.3f;
        sphereCollider.isTrigger = true;
        
        Debug.Log(transform.name + " LoadSphereCollider",gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;
        ItemDropCtrl itemDropCtrl = other.transform.parent.GetComponent<ItemDropCtrl>();
        if (itemDropCtrl == null) return;
        itemDropCtrl.Despawn.DoDespawn();
    }
}
