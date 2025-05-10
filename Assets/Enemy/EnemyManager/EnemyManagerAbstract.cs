using UnityEngine;

public abstract class EnemyManagerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected EnemyManagerCtrl enemyManagerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyManagerCtrl();
    }

    protected virtual void LoadEnemyManagerCtrl()
    {
        if (enemyManagerCtrl != null) return;
        this.enemyManagerCtrl = transform.GetComponentInParent<EnemyManagerCtrl>();
        
        Debug.Log(transform.name + ": LoadEnemyManagerCtrl", gameObject);
    }
}
