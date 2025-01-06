using UnityEngine;

public abstract class DamageReceiver : TungMonoBehaviour
{
    [SerializeField] protected int currentHP = 10;
    public int CurrentHP => currentHP;

    [SerializeField] protected int maxHP = 10;
    public int MaxHP => maxHP;

    [SerializeField] protected bool isDead = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected abstract void LoadCollider();
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    public virtual void Deduct(int damage)
    {
        this.currentHP -= damage;
        if(this.IsDead()) this.OnDead();
    }
    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }
    protected virtual void Reborn()
    {
        this.currentHP = this.maxHP;
    }
    protected abstract void OnDead();
}
