using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : NamMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        UnityEngine.Debug.Log(transform.name + "Loaded inventory", gameObject);
    }
}
