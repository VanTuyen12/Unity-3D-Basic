using UnityEngine;

public class BulletCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => this.bullet;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
        
    }

    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = this.GetComponent<Bullet>();
        
        Debug.Log(transform.name + ": LoadBullet() ", gameObject);
    }
}
