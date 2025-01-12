using UnityEngine;

public class PlayerHealing : PlayerAbstract
{
    [SerializeField] protected float timer = 0;
    public float Timer => timer;

    [SerializeField] protected float timeDeley = 5f;
    private void Update()
    {
        this.HotkeyHealing();
        this.CanHeal();
    }
    public virtual void Heal()
    {
        if (!this.CanHeal()) return;
        ItemInventory itemInventory = InventoryManager.Instance.InventoryCtrl.FindItem(ItemCode.Health);
        if (itemInventory == null) return;
        bool isHeal = playerCtrl.DamageReceiver.Healing(10);
        if (!isHeal) return;
        itemInventory.Deduct(1);
        this.timer = this.timeDeley; 
    }
    protected virtual void HotkeyHealing()
    {
        if(InputManager.Instance.IsHealing) this.Heal();
    }
    protected virtual bool CanHeal()
    {
        if(this.timer <= 0)
        {
            this.timer = 0;
            return true;
        }
        this.timer -= Time.deltaTime;
        return false;
    }
}
