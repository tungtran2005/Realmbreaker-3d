using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnerCtrl : TungSingleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner spawner;
    public EffectSpawner Spawner => spawner;
    [SerializeField] protected EffectPrefabs prefabs;
    public EffectPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EffectSpawner>();
        Debug.Log(transform.name + " : LoadSpawner ", gameObject);
    }
    protected virtual void LoadPrefabs()
    {
        if(this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<EffectPrefabs>();
        Debug.Log(transform.name + " : LoadPrefabs", gameObject);
    }
}
