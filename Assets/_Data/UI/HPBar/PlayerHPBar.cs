using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : PlayerAbstract
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int minHP;
    private void FixedUpdate()
    {
        this.DisPlayHP();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSilder();
        this.LoadHP();

    }
    protected override void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = FindAnyObjectByType<PlayerCtrl>();
        Debug.Log(transform.name + " : LoadPlayerCtrl", gameObject);
    }
    protected virtual void LoadSilder()
    {
        if (this.slider != null) return;
        this.slider = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + " : LoadSilder", gameObject);
    }
    protected virtual void LoadHP()
    {
        this.maxHP = this.playerCtrl.DamageReceiver.MaxHP;
        this.minHP = 0;
        this.slider.maxValue = this.maxHP;
        this.slider.minValue = this.minHP;
    }

    protected virtual void DisPlayHP()
    {
        this.slider.value = this.playerCtrl.DamageReceiver.CurrentHP;
    }
}
