using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    public CapsuleCollider CapsuleCollider => capsuleCollider;

    [SerializeField] protected EnemyDespawn despawn;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override DamageReceiver Send(Collider collider)
    {
        PlayerDamageReceiver damageReceiver = collider.GetComponentInChildren<PlayerDamageReceiver>();
        if (damageReceiver == null) return null;
        damageReceiver.Deduct(this.damage);
        //this.despawn.DoDespawn();
        return damageReceiver;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + " : LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.parent.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + " : LoadDespawn", gameObject);
    }
    protected override void LoaCollider()
    {
        if (this._Collider != null) return;
        this._Collider = GetComponent<Collider>();
        this.capsuleCollider = (CapsuleCollider)this._Collider;
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.center = new Vector3(0, 1, 0);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 2f;
        Debug.Log(transform.name + " : LoaCollider", gameObject);
    }
}
