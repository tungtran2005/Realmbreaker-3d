using UnityEngine;

public class TextHealCooldownTimer : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadHealCooldownTimer();
    }
    protected virtual void LoadHealCooldownTimer()
    {
       float timer = PlayerCtrl.Instance.PlayerHealing.Timer;
        this.textMeshProUGUI.text = timer.ToString("F2");
    }
}
