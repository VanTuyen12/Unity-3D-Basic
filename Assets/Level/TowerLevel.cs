using UnityEngine;

public class TowerLevel : LevelAbstract
{
    [SerializeField] protected TowerCtrl towerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }
    
    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + " LoadTowerCtrl(): ", gameObject);
    }
    protected override int GetCurrentLevel()
    {
        return towerCtrl.TowerShooting.KillCount;
    }

    protected override bool DeductExp(int exp)
    {
        return towerCtrl.TowerShooting.DeductKillCount(exp);
    }
    
    protected override int GetNextLevelExp()//diem exp can de len lv
    {
        return this.nextLevelExp = this.currentLevel * 2;
    }
}
