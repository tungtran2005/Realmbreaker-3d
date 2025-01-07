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
        this.capsuleCollider.enabled = false;
        this.enemyCtrl.DamageSender.CapsuleCollider.enabled = false;
        this.enemyCtrl.Animator.SetBool("isDead", this.isDead);
        Invoke(nameof(this.DoDespawn), 3f);
        this.RandItem();
    }
    protected virtual void DoDespawn()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
        this.enemyCtrl.DamageSender.CapsuleCollider.enabled = true;
    }
    protected virtual void RandItem()
    {
        InventoryManager.Instance.AddItem(ItemCode.ExpPlayer, 1);
        int rand = Random.Range(0, 10);
        if(rand >=0 && rand <= 5)
        {
            InventoryManager.Instance.AddItem(ItemCode.Health, 1);
        }
    }
}
