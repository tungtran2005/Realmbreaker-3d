using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTestFollowPlayer : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Transform player;
    private void Reset()
    {
        this.LoadAgent();
        this.LoadPlayer();
    }
    private void Update()
    {
        this.agent.SetDestination(this.player.position);
    }
    protected virtual void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + " : LoadAgent", gameObject);
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("ThirdPersonController").transform;
        Debug.Log(transform.name + " : LoadPlayer", gameObject);
    }

}
