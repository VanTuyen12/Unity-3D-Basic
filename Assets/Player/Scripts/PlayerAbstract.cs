using UnityEngine;

public abstract class PlayerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtr();
    }

    protected virtual void LoadPlayerCtr()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();

        Debug.Log(transform.name + " :LoadPlayerCtr ", gameObject);
    }
}