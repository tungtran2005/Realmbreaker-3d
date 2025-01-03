using UnityEngine;

public class FollowPlayer : EnemyAbstract
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected bool isMoving = false;
    private void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        if(this.playerCtrl == null) this.enemyCtrl.Agent.isStopped = true;
        this.LoadMovingStatus();
        this.enemyCtrl.Agent.SetDestination(this.playerCtrl.transform.position);
    }
    protected virtual void LoadMovingStatus()
    {
        this.isMoving = !this.enemyCtrl.Agent.isStopped;
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.FindAnyObjectByType<PlayerCtrl>();
        Debug.Log(transform.name + " : LoadPlayerCtrl", gameObject);
    }
}
