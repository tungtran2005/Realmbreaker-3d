using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReborning : TungMonoBehaviour
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 4f;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new List<EnemyCtrl>();

    private void FixedUpdate()
    {
        this.CreateEnemy();
    }
    protected virtual void CreateEnemy()
    {
        if (this.spawnedEnemies.Count >= this.maxSpawn) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        EnemyCtrl prefab = EnemySpawnerCtrl.Instance.Prefabs.GetRandom();
        EnemyCtrl newEnemy = EnemySpawnerCtrl.Instance.Spawner.Spawn(prefab,transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }
}
