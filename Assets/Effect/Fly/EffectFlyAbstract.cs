using UnityEngine;

public abstract class EffectFlyAbstract : EffectCtrl
{
    //Nhom lai cac hieu ung bay thang 
    [SerializeField] protected FlyToTarget flyToTarget;
    
    public FlyToTarget FlyToTarget => flyToTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlyToTarget();
    }

    protected virtual void LoadFlyToTarget()
    {
        if (this.flyToTarget != null) return;
        this.flyToTarget = GetComponentInChildren<FlyToTarget>();
        
        Debug.Log(transform.name + " :LoadFlyToTarget ",gameObject);
    }
}
