using UnityEngine;

public class AttackLight : AttackAbstract
{
    
    protected string effectName = "ProjectTile2";
    
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;
        AttackPoint attackPoint = this.GetAttrackPoint();
        
        EffectCtrl effect = this.spawner.Spawn(this.GetEffect(),attackPoint.transform.position);//Spawn no o vtri nao
        
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;//Ep kieu
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);
        
        effect.gameObject.SetActive(true);
        
    }

    protected virtual EffectCtrl GetEffect()
    {
        return prefabs.GetByName(effectName);
    }
}
