using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectPrefabs prefabs ;
    [SerializeField] protected EffectSpawner spawner;
    protected abstract void Attacking();
    
    protected void Update()
    {
        this.Attacking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
        this.LoadEffectPrefabs();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        
        Debug.Log(transform.name + " :LoadPlayerCtrl" ,gameObject);
    }
    protected virtual void LoadEffectSpawner()
    {
        if (spawner != null) return;
        spawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        
        Debug.Log(transform.name + " :LoadEffectSpawner" ,gameObject);
    }
    protected virtual void LoadEffectPrefabs()
    {
        if (prefabs != null) return;
        prefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        
        Debug.Log(transform.name + " :LoadEffectPrefabs" ,gameObject);
    }

    protected virtual AttackPoint GetAttrackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;//vtri tan cong
    }
}
