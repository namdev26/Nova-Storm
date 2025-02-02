using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : NamMonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Rigidbody _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadTrigger();
        this.LoadRigidbody();
    }

    protected virtual void LoadInventory()
    {
        if (this._inventory != null) return;
        this._inventory = transform.parent.GetComponent<Inventory>();
        Debug.Log(transform.name + " loaded in inventory", gameObject);
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

        Debug.Log(collider.name);
        Debug.Log(collider.transform.parent.name);
        Debug.Log("Can pick up");
    }
}
