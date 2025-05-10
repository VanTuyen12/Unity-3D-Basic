using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Transform model;
    [SerializeField] protected Animator animator;
    [SerializeField] protected TowerTagertable towerTagertable;
    
    public NavMeshAgent Agent => agent;
    public Animator Animator => animator;
    
    public TowerTagertable TowerTagertable => towerTagertable;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.loadTowerTagertable();
        this.LoadAnimator();
    }
    
  
    protected virtual void LoadModel()
    {
        if (this.model != null) return;

        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0f, 0f, 0f);

        //Debug.Log(transform.name + " LoadModel : ", gameObject);
    }
    
    protected virtual void loadTowerTagertable()
    {
        if (this.towerTagertable != null) return;

        this.towerTagertable = transform.GetComponentInChildren<TowerTagertable>();
        towerTagertable.transform.localPosition = new Vector3(0f, 0.5f, 0f);

        //Debug.Log(transform.name + " LoadModel : ", gameObject);
    }
    
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator =this.model.GetComponent<Animator>();
        //Debug.Log(transform.name + " animation : ", gameObject);
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null)
            return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 2;
        this.agent.angularSpeed = 200;
        this.agent.acceleration = 150;

        //Debug.Log(transform.name + " LoadNavMeshAgent : ", gameObject);
    }
    
}