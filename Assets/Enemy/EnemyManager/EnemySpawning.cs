using System.Collections.Generic;
using Unity.VisualScripting;
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

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning),this.spawnSpeed);
        EnemyCtrl prefab = this.enemyManagerCtrl.EnemyPrefabs.GetRandom();
        EnemyCtrl newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab,transform.position);
        
        newEnemy.gameObject.SetActive(true);
        
        Debug.Log("Spawning: " + prefab.name);
    }

    
}
