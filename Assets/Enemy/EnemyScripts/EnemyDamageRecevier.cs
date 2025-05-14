using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageRecevier : DamageRecever
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
    }
    
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        
        Debug.Log(transform.name + "LoadEnemyCtrl ", gameObject);
    }
    
    protected virtual void LoadCapsuleCollider()
    {
        if (capsuleCollider != null) return;
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;
        capsuleCollider.radius = 0.3f;
        capsuleCollider.height = 2f;
        capsuleCollider.center = new Vector3(0, 1, 0);

        Debug.Log(transform.name + " :LoadCapsuleCollider", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.enemyCtrl.Animator.SetBool("isDead",this.isDead);
        this.capsuleCollider.enabled = false;
        Invoke(nameof(Disappear),3f);
    }

    protected virtual void Disappear()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }
    protected override void OnHurt()
    {
        base.OnHurt();
        this.enemyCtrl.Animator.SetTrigger("isHurt");
    }

    protected override void OnReborn()
    {
        base.OnReborn();
        this.capsuleCollider.enabled = true;
    }
}