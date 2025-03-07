using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver DamageReceiver => damageReceiver;
    [SerializeField] protected EnemyDamageSender damageSender;
    public EnemyDamageSender DamageSender => damageSender;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadEnemyDamageReceiver();
        this.LoadDamageSender();
    }
    protected virtual void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + " : LoadAgent", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + " : LoadAnimator", gameObject);
    }
    protected virtual void LoadEnemyDamageReceiver()
    {
        if(this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + " : LoadEnemyDamageReceiver", gameObject);
    }
    protected virtual void LoadDamageSender()
    {
        if(this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<EnemyDamageSender>();
        Debug.Log(transform.name + " : LoadDamageSender", gameObject);
    }
}
