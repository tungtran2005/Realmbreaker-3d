using UnityEngine;
[RequireComponent (typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyDespawn despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoaDespawn();
    }
    protected virtual void LoaDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.parent.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + " : LoadDesapwn", gameObject);
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
        this.despawn.DoDespawn();
    }
}
