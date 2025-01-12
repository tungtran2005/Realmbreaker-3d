using UnityEngine;

public class HealthBtn : ButtonAbstract
{
    public override void OnClick()
    {
        PlayerCtrl.Instance.PlayerHealing.Heal();
    }
}
