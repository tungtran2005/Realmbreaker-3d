using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReborning : TungMonoBehaviour
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 4f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<RebornPoint> rebornPoint = new List<RebornPoint>();
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new List<EnemyCtrl>();

    private void FixedUpdate()
    {
        this.CreateEnemy();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRebornPoint();
    }
    protected virtual void LoadRebornPoint()
    {
        if(this.rebornPoint.Count > 0) return;
        RebornPoint[] points = GetComponentsInChildren<RebornPoint>();
        this.rebornPoint = new List<RebornPoint>(points);
        Debug.Log(transform.name + " : LoadRebornPoint",gameObject);
    }
    protected virtual void CreateEnemy()
    {
        if (this.spawnedEnemies.Count >= this.maxSpawn) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        EnemyCtrl prefab = EnemySpawnerCtrl.Instance.Prefabs.GetRandom();
        this.pointIndex = GetRebornPoint();
        EnemyCtrl newEnemy = EnemySpawnerCtrl.Instance.Spawner.Spawn(prefab, this.rebornPoint[this.pointIndex].transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }
    protected virtual int GetRebornPoint()
    {
        int rand = Random.Range(0, this.rebornPoint.Count);
        return rand;
    }
}
