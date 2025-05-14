using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class WallDamageReceiver : DamageRecever
{
    [SerializeField] BoxCollider boxCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if(this.boxCollider != null) return;
        this.boxCollider = this.GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = false;
        
        Debug.Log(transform.name + " LoadBoxCollider", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isImmotal = true;
    }
}
