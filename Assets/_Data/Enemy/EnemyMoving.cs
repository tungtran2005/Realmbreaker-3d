using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMoving : EnemyAbstract
{
    [SerializeField] protected Vector3 originPoint = new Vector3(0, 0 , 0);
    [SerializeField] protected Vector3 currentPoint;
    [SerializeField] protected float scope = 5f;
    [SerializeField] protected float waitTime = 3f;
    [SerializeField] protected float waitTimer = 0;

    private void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.waitTimer += Time.fixedDeltaTime;
        if (this.waitTimer < this.waitTime) return;
        this.waitTimer = 0;
        this.currentPoint = this.NextPoint();
        this.enemyCtrl.Agent.SetDestination(this.currentPoint);
    }
    protected virtual Vector3 NextPoint()
    {
        float posx = this.originPoint.x + Random.Range(-this.scope, this.scope);
        float posz = this.originPoint.z + Random.Range(-this.scope, this.scope);
        Vector3 newPoint = new Vector3(posx, this.originPoint.y, posz);
        return newPoint;
    }
}
