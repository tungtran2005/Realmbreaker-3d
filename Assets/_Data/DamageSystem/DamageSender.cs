using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public abstract class DamageSender : TungMonoBehaviour
{
    [SerializeField] protected int damage = 5;
    [SerializeField] protected Rigidbody _Rigidbody;
    [SerializeField] protected Collider _Collider;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.Send(collider);
    }
    protected virtual DamageReceiver Send(Collider collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return null;
        damageReceiver.Deduct(this.damage);
        return damageReceiver;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoaCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoaCollider()
    {
        if (this._Collider != null) return;
        this._Collider = GetComponent<Collider>();
        this._Collider.isTrigger = true;
        Debug.Log(transform.name + " : LoaCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._Rigidbody != null) return;
        this._Rigidbody = GetComponent<Rigidbody>();
        this._Rigidbody.useGravity = false;
        Debug.Log(transform.name + " : LoadRigidbody", gameObject);
    }
}
