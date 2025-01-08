using UnityEngine;

public class SoundSpawnerCtrl : TungSingleton<SoundSpawnerCtrl>
{
    [SerializeField] protected SoundSpawner spawner;
    public SoundSpawner Spawner => spawner;
    [SerializeField] protected SoundPrefab prefabs;
    public SoundPrefab Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<SoundSpawner>();
        Debug.Log(transform.name + " : LoadSpawner ", gameObject);
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<SoundPrefab>();
        Debug.Log(transform.name + " : LoadPrefabs", gameObject);
    }
}
