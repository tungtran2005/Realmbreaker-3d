using System;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    [SerializeField] protected string itemName;
    public string ItemName => itemName;

    protected ItemProfileSO itemProfileSO;
    public ItemProfileSO ItemProfileSO => itemProfileSO;

    [SerializeField] protected int itemCount;
    public int ItemCount => itemCount;

    public ItemInventory(ItemProfileSO itemProfileSO, int itemCount)
    {
        this.itemProfileSO = itemProfileSO;
        this.itemCount = itemCount;
        this.itemName = itemProfileSO.itemName;
    }
    public virtual void SetName(string name)
    {
        this.itemName = name;
    }
    public virtual string GetItemName()
    {
        if (this.itemName == null || this.itemName == "") return this.itemProfileSO.itemName;
        return this.itemName;
    }
    public virtual void Add(int num)
    {
        this.itemCount += num;
    }
    public virtual bool Deduct(int num)
    {
        if (!this.CanDeduct(num)) return false;
        this.itemCount -= num;
        return true;
    }
    public virtual bool CanDeduct(int num)
    {
        return (this.itemCount >= num);
    }
}
