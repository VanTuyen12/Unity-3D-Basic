using System;
using UnityEngine;

public class MuzzleEffect : SaiMonoBehaviour
{
   [SerializeField] protected MuzzleCode muzzle;

   protected virtual void OnEnable()
   {
      this.SpawnMuzzle();
   }

   protected virtual void SpawnMuzzle()
   {
      if (muzzle == MuzzleCode.NoMuzzle ) return; // neu no trong thi rt
      EffectSpawner effectSpawner = EffectSpawnerCtrl.Instance.Spawner;

      EffectCtrl prefab = effectSpawner.PoolPrefabs.GetByName(this.muzzle.ToString());
      EffectCtrl effectCtrl = effectSpawner.Spawn(prefab,transform.position);
      
      effectCtrl.gameObject.SetActive(true);
   }
}
