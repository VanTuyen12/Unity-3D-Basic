using UnityEngine;

public class EnemyHp : SliderHp
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if(this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name+ " :LoadEnemyCtrl",gameObject);
    }

    protected override float GetValue()
    {
        return enemyCtrl.EnenyDamageRecever.CurrentHP / (float)enemyCtrl.EnenyDamageRecever.MaxHP;
    }
}
