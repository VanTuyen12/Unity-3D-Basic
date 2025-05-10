using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damege = 1;
    [SerializeField] protected Rigidbody rigid;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }
    protected virtual void LoadRigibody()
    {
        if (rigid != null) return;
        rigid = this.GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        
        Debug.Log(transform.name + "LoadRigibody ", gameObject);
    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        DamageRecever damageRecever = collider.GetComponent<DamageRecever>();
        if (damageRecever == null) return;
        this.Send(damageRecever);
        
        Debug.Log("OnTriggerEnter: " + collider.name);
    }

    protected virtual void Send(DamageRecever damegeRecever)
    {
        damegeRecever.Deduct(this.damege);
    }
}
