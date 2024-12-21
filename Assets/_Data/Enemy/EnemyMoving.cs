using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMoving : EnemyAbstract
{
    [SerializeField] protected Vector3 originPoint = new Vector3(0, 0 , 0);
    [SerializeField] protected Vector3 currentPoint;
    [SerializeField] protected float scope = 5f;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float pointDistanceLimit = 1f;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected float time = 2f;
    [SerializeField] protected float timer = 0;
    private void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.LoadMovingStatus();
        this.NextPoint();
        this.enemyCtrl.Agent.SetDestination(this.currentPoint);
    }
    protected virtual void NextPoint()
    {
        this.pointDistance = Vector3.Distance(this.currentPoint, this.transform.parent.position);
        if (this.pointDistance > this.pointDistanceLimit) return;
        this.enemyCtrl.Agent.isStopped = true;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.time) return;
        this.timer = 0;
        this.enemyCtrl.Agent.isStopped = false;
        this.RanPoint();
    }
    protected virtual void RanPoint()
    {
        float posx = this.originPoint.x + Random.Range(-this.scope, this.scope);
        float posz = this.originPoint.z + Random.Range(-this.scope, this.scope);
        Vector3 newPoint = new Vector3(posx, this.originPoint.y, posz);
        this.currentPoint = newPoint;
    }
    protected virtual void LoadMovingStatus()
    {
        this.isMoving = !this.enemyCtrl.Agent.isStopped;
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
}
