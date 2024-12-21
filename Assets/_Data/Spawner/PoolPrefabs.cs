using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolPrefabs<T> : TungMonoBehaviour where T : PoolObj
{
    [SerializeField] protected List<T> prefabs = new();
    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach(Transform child in transform)
        {
            if(child != null)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count > 0) return;
        foreach(Transform child in transform)
        {
            T prefab = child.GetComponent<T>();
            if(prefab != null)
            {
                this.prefabs.Add(prefab);
            }
        }
        Debug.Log(transform.name + " : LoadPrefabs", gameObject);
    }
    public virtual T GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
    public virtual T GetByName(string namePrefab)
    {
        foreach(T prefab in this.prefabs)
        {
            if(prefab.name == namePrefab) return prefab;
        }
        return null;
    }
}
