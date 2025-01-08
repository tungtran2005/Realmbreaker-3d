using UnityEngine;

public class Muzzle1Despawn : EffectDespawn
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLife = 1;
        this.currentTime = 1;
    }
}
