using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn<EnemyCtrl>
{
    protected override void LoadValue()
    {
        base.LoadValue();
        this.timeLife = 60f;
        this.currentTime = 60f;
    }
}
