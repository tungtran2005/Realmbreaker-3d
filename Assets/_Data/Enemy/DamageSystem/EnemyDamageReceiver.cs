using UnityEngine;
[RequireComponent (typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected CapsuleCollider capsuleCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadCollider();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + " : LoadEnemyCtrl", gameObject);
    }
    protected override void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.center = new Vector3 ( 0, 1, 0);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 2f;
        Debug.Log(transform.name + " : LoadCollider", gameObject);
    }
    protected override void OnDead()
    {
        this.enemyCtrl.Agent.isStopped = true;
        this.enemyCtrl.Animator.SetBool("isDead", this.isDead);
        Invoke(nameof(this.DoDespawn), 3f);
    }
    protected virtual void DoDespawn()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }
}
