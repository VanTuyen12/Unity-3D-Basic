using System;
using System.Collections;
using System.Collections.Generic;
using Paths;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : SaiMonoBehaviour
{
    //[SerializeField] protected int pathIndex = 0 ;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected string pathName = "Path_1";
    [SerializeField] protected PathMoving emenyPath;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity ;//Vo cuc
    [SerializeField] protected float stopDistance = 1f;
    [SerializeField] protected bool isFinsh = false;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected bool canMove = true; // dang di chuyen

    protected virtual void OnEnable()
    {
        this.OnReborn();
    }
    

    protected override void Start()
    {
        this.LoadEmenyPath();
    }

    private void FixedUpdate()
    {
        this.Moving();
        this.CheckMoving();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        //this.loadTarget();
    }

    /*protected virtual void loadTarget()
    {
        if (this.target != null) return;

        this.target = GameObject.Find("TargetMoving"); //Tìm tagert bằng tên
        //Debug.Log(transform.name + ": TargetMoving ", gameObject);
    }*/

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>(); // tranform đại diện thk con, parent đại dện thk cha
        Debug.Log(transform.name + " : LoadEnemyCtrl ", gameObject);
    }

    protected virtual void Moving()
    {
        if (!this.canMove) 
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
        
        if (this.enemyCtrl.EnenyDamageRecever.IsDead()) 
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
        
        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinsh == true)
        { 
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
        this.enemyCtrl.Agent.isStopped = false;
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
        //this.enemyCtrl.Agent.SetDestination(target.transform.position);
    }

    protected virtual void FindNextPoint()
    {
        if (this.currentPoint == null) this.currentPoint = this.emenyPath.GetPoint(0);
        
        this.pointDistance = Vector3.Distance(transform.position,this.currentPoint.transform.position);//Kc cua 2 doi tg
        if (this.pointDistance < this.stopDistance)
        {
            this.currentPoint = this.currentPoint.NextPoint;
            if (this.currentPoint == null) this.isFinsh = true;
            
        }
    }
    protected virtual void LoadEmenyPath()
    {
        if (emenyPath != null) return;
        //this.enemyPath = PathsManager.Instance.GetPath(this.pathIndex);
        this.emenyPath = PathsManager.Instance.GetPath(this.pathName);
        //Debug.Log(transform.name + ": LoadEmenyPath ", gameObject);
    }

    protected virtual void CheckMoving()
    {
        if (this.enemyCtrl.Agent.velocity.magnitude>0.1f) this.isMoving = true;
        else this.isMoving = false;
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
    
    protected virtual void OnReborn()
    {
        this.isFinsh = false;
        this.currentPoint = null;
    }
}