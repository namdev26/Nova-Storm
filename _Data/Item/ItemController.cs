using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController : NamMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.parent.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": Load ItemDespawn", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.itemInventory.itemCount = 1;
        this.ResetItem();
        Debug.Log(transform.name + ": Load ItemInventory", gameObject);
    }

    private void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }

}
