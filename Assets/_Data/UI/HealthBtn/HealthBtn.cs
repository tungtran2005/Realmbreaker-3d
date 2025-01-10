using UnityEngine;

public class HealthBtn : ButtonAbstract
{
    protected override void OnClick()
    {
        ItemInventory itemInventory = InventoryManager.Instance.InventoryCtrl.FindItem(ItemCode.Health);
        if (itemInventory == null) return;
        this.Heal(itemInventory);
    }
    protected virtual void Heal(ItemInventory itemInventory)
    {
        bool isHeal = PlayerCtrl.Instance.DamageReceiver.Healing(10);
        if (!isHeal) return;
        itemInventory.Deduct(1);
    }
}
