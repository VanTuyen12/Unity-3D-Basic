using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySort : MonoBehaviour
{
    private List<Enemy> enemiess = new List<Enemy>();
    private EnemyManager enemyManager;
    private void Awake()
    {
        LoandComponents();
    }

    private void LoandComponents()
    {
        if (this.enemyManager != null) return;
        enemyManager = GetComponent<EnemyManager>();
        //Debug.Log(transform.name + ": LoadComponents");
        //enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Sorting();
        ShowSorting();
    }

    protected virtual void Sorting()
    {
        this.enemiess = this.enemyManager.Enemies;
        
        for (int i = 1; i < enemiess.Count; i++)
        {
            Enemy key = enemiess[i];
            int j = i - 1;

            // Di chuyển các phần tử lớn hơn key sang bên phải
            while (j >= 0 && enemiess[j].GetWeight() > key.GetWeight())
            {
                enemiess[j + 1] = enemiess[j];
                j--;
            }

            enemiess[j + 1] = key;
        }
    }

    protected virtual void ShowSorting()
    {
        foreach (var enemy in enemiess)
        {
            //Debug.Log("Enemy weight: " + enemy.GetWeight());
        }
    }
}
