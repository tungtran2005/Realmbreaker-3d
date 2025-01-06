using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory itemInventory;
    protected abstract ItemCode GetItemCode();
    public override int GetCurrentExp()
    {
        if(this.GetItemInventory() == null) return 0;
        return this.GetItemInventory().ItemCount;
    }
    protected override bool DeductExp(int exp)
    {
        return this.GetItemInventory().Deduct(exp);
    }
    protected virtual ItemInventory GetItemInventory()
    {
        this.itemInventory = InventoryManager.Instance.InventoryCtrl.FindItem(this.GetItemCode());
        return this.itemInventory;
    }

}
