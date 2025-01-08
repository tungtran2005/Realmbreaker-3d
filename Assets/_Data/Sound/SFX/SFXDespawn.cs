using UnityEngine;

public class SFXDespawn : Despawn<SoundCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLife = 1f;
        this.currentTime = 1f;
    }
}
