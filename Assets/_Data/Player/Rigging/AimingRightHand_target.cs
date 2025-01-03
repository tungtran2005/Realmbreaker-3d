using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : TungMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.297f, 0.09f, 0.75f);
        transform.localRotation = Quaternion.Euler(-5.771f, -66.121f, -88.858f);
    }
}
