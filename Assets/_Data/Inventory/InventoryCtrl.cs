using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl : TungMonoBehaviour
{
    [SerializeField] protected List<ItemInventory> items = new();
    public List<ItemInventory> Items => items;


    public virtual void AddItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItem(item.ItemProfileSO.itemCode);
        if (itemExist == null)
        {
            this.items.Add(item);
            return;
        }
        itemExist.Add(item.ItemCount);
    }

    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmpty(item.ItemProfileSO.itemCode);
        if (itemExist == null) return false;
        if (!itemExist.CanDeduct(item.ItemCount)) return false;
        itemExist.Deduct(item.ItemCount);
        if (itemExist.ItemCount == 0) this.items.Remove(itemExist);
        return true;
    }

    public virtual ItemInventory FindItem(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemProfileSO.itemCode == itemCode) return itemInventory;
        }

        return null;
    }
    public virtual ItemInventory FindItemNotEmpty(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemProfileSO.itemCode != itemCode) continue;
            if (itemInventory.ItemCount > 0) return itemInventory;
        }

        return null;
    }


}
