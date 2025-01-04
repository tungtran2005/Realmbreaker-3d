using System.Collections.Generic;
using UnityEngine;

public class EnemyReborning : TungMonoBehaviour
{
    [SerializeField] protected float spawnSpeed = 4f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<RebornPoint> rebornPoint = new List<RebornPoint>();
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new List<EnemyCtrl>();

    protected override void Start()
    {
        Invoke(nameof(this.CreateEnemy), this.spawnSpeed);
    }
    private void FixedUpdate()
    {
        this.RemoveOnDead();
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
        Invoke(nameof(this.CreateEnemy), spawnSpeed);
        if (this.spawnedEnemies.Count >= this.maxSpawn) return;

        EnemyCtrl prefab = EnemySpawnerCtrl.Instance.Prefabs.GetRandom();
        this.pointIndex = GetRebornPoint();
        EnemyCtrl newEnemy = EnemySpawnerCtrl.Instance.Spawner.Spawn(prefab, this.rebornPoint[this.pointIndex].transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }
    protected virtual void RemoveOnDead()
    {
        foreach(EnemyCtrl enemy in this.spawnedEnemies)
        {
            if (enemy.DamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemy);
                return;
            }
        }
    }
    protected virtual int GetRebornPoint()
    {
        int rand = Random.Range(0, this.rebornPoint.Count);
        return rand;
    }
}
