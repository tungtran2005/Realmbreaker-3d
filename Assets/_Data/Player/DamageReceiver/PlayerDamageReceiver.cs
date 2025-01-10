using UnityEngine;
//[RequireComponent(typeof(CapsuleCollider))]
public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.currentHP = 100;
        this.maxHP = 100;
    }
    protected override void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponentInParent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3 (0, 1, 0);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 2f;
        Debug.Log(transform.name + " : LoadCollider", gameObject);
    }

    protected override void OnDead()
    {
        GameOverManager.Instance.GameOver();
    }
    public virtual bool Healing(int hp)
    {
        if(this.currentHP == this.maxHP) return false;
        this.currentHP += hp;
        if(this.currentHP > this.maxHP) this.currentHP = this.maxHP;
        return true;
    }
}
