using UnityEngine;

public class TextHealthCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadHealthCount();
    }
    protected virtual void LoadHealthCount()
    {
        ItemInventory itemInventory = InventoryManager.Instance.InventoryCtrl.FindItem(ItemCode.Health);
        if (itemInventory == null) this.textMeshProUGUI.text = "0";
        else this.textMeshProUGUI.text = itemInventory.ItemCount.ToString();
    }
}
