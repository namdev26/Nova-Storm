using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : InventoryAbstract
{
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Rigidbody _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadTrigger();
        this.LoadRigidbody();
    }
    protected virtual void LoadTrigger()
    {
        if (this._sphereCollider != null) return;
        this._sphereCollider = GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = 0.35f;
        Debug.Log(transform.name + " loaded with trigger", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + " loaded with rigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemController.ItemInventory;

        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
