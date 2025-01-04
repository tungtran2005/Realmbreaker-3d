using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : TungSingleton<InventoryManager>
{
    [SerializeField] protected InventoryCtrl inventoryCtrl;
    public InventoryCtrl InventoryCtrl => inventoryCtrl;

    [SerializeField] protected List<ItemProfileSO> itemProfileSOs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadItemProfileSO();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = GetComponentInChildren<InventoryCtrl>();
        Debug.Log(transform.name + " : LoadInventory", gameObject);
    }
    protected virtual void LoadItemProfileSO()
    {
        if (this.itemProfileSOs.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfileSOs = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfileSO", gameObject);
    }
    public virtual ItemProfileSO GetItemProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO itemProfileSO in this.itemProfileSOs)
        {
            if(itemProfileSO.itemCode == itemCodeName) return itemProfileSO;
        }
        return null;
    }
    public virtual void AddItem(ItemInventory itemInventory)
    {
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfileByCode(itemCode);
        ItemInventory item = new ItemInventory(itemProfile, itemCount);
        this.AddItem(item);
    }
    public virtual void RemoveItem(ItemInventory itemInventory)
    {
        inventoryCtrl.RemoveItem(itemInventory);
    }
    public virtual void RemoveItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.RemoveItem(item);
    }

    
}
