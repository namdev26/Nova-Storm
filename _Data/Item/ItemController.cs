using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : NamMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
    }
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.parent.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": Load ItemDespawn", gameObject); 
    }
}
