using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();

    public List<Enemy> Enemies
    {
        get {return enemies;}
    }
    // Giong <=> public List<Enemy> Enemies => enemies;
    
    private Enemy smallestEnemy;
    private Enemy biggesEnemy;

    private void Awake()
    {
        this.LoadEnemies();
    }

    private void Start()
    {
        LoadSmallestEnemy();
        LoadBiggestEnemy();
    }

    protected virtual void LoadSmallestEnemy()
    {
        Enemy fistEnemy = this.enemies[0];
        float smallestWeight = fistEnemy.GetWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeeight = enemy.GetWeight();

            if (enemyWeeight <= smallestWeight)
            {
                smallestWeight = enemyWeeight;
                this.smallestEnemy = enemy;
            }

            //Debug.Log(enemy.GetObjName() + "" + enemy.GetWeight());
        }
    }

    protected virtual void LoadBiggestEnemy()
    {
        Enemy fistEnemy = this.enemies[0];
        float biggestWeight = fistEnemy.GetWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeeight = enemy.GetWeight();

            if (enemyWeeight >= biggestWeight)
            {
                biggestWeight = enemyWeeight;
                this.biggesEnemy = enemy;
            }
            //Debug.Log(enemy.GetObjName()+""+ enemy.GetWeight());
        }
    }

    protected virtual void LoadEnemies()
    {
        foreach (Transform childObj in transform)
        {
            //Debug.Log(childObj.name);
            Enemy enemy = childObj.GetComponent<Enemy>();
            if (enemy == null) continue; // bo qua tiep tuc
            this.enemies.Add(enemy);
        }
    }
}