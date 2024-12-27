using UnityEngine;
[RequireComponent (typeof(SphereCollider))]
public class BulletDamgeSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EffectDespawn despawn;

    protected override DamageReceiver Send(Collider collider)
    {
        DamageReceiver damageReceiver = base.Send(collider);
        if (damageReceiver == null) return null;
        this.despawn.DoDespawn();
        return damageReceiver;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.parent.GetComponentInChildren<EffectDespawn>();
        Debug.Log(transform.name + " : LoadDespawm", gameObject);
    }
    protected override void LoaCollider()
    {
        if(this._Collider != null) return;
        this._Collider = GetComponent<Collider>();
        this._Collider.isTrigger = true;
        this.sphereCollider = (SphereCollider)this._Collider;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + " : LoaCollider", gameObject);
    }

}
