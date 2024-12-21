using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : TungSingleton<EnemySpawnerCtrl>
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;
    [SerializeField] protected EnemyPrefabs prefabs;
    public EnemyPrefabs Prefabs => prefabs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadEnemyPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EnemySpawner>();
        Debug.Log(transform.name + " : LoadSpawner", gameObject);
    }
    protected virtual void LoadEnemyPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<EnemyPrefabs>();
        Debug.Log(transform.name + " : LoadEnemyPrefabs", gameObject);
    }
}
