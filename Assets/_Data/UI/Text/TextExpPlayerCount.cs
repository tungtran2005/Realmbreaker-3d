using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExpPlayerCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadExpPlayerCount();
    }
    protected virtual void LoadExpPlayerCount()
    {
        ItemInventory itemInventory = InventoryManager.Instance.InventoryCtrl.FindItem(ItemCode.ExpPlayer);
        if (itemInventory == null) this.textMeshProUGUI.text = "0";
        else this.textMeshProUGUI.text = itemInventory.ItemCount.ToString();
    }
}
