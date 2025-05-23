using UnityEngine;

    public abstract class TowerAbstract : SaiMonoBehaviour
    {
        [SerializeField] protected TowerCtrl towerCtrl;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTowerCtrl();
        }

        protected virtual void LoadTowerCtrl()
        {
            if(towerCtrl != null) return;
            towerCtrl = transform.parent.GetComponent<TowerCtrl>();
            Debug.Log(transform.name + ": LoadTowerCtrl() " ,gameObject);
        }
    }
