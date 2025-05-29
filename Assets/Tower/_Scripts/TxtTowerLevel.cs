using UnityEngine;

public class TxtTowerLevel : TxtLevel
{
    [SerializeField] protected TowerCtrl towerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (towerCtrl != null) return;
        towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }

    protected override string GetLevel()
    {
        return towerCtrl.Level.CurrentLevel.ToString();
    }
}
