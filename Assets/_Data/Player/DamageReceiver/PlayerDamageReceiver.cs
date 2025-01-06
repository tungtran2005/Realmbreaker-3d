using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.currentHP = this.maxHP;
    }
}
