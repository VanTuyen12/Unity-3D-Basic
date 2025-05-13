using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] private float spawnSpeed = 2f;
    [SerializeField] private int maxSpawn = 10;
    protected List<EnemyCtrl> spawnedEnemies = new();

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning),this.spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();//Ktra enemy deal chua thi xoa trong list
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning),this.spawnSpeed);
        
        if(this.spawnedEnemies.Count >= this.maxSpawn) return;
        EnemyCtrl prefab = this.enemyManagerCtrl.EnemyPrefabs.GetRandom();
        
        EnemyCtrl newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab,transform.position);
        newEnemy.gameObject.SetActive(true);
        
        this.spawnedEnemies.Add(newEnemy);
        
        Debug.Log("Spawning: " + prefab.name);
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnenyDamageRecever.IsDead())
            {
                spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
