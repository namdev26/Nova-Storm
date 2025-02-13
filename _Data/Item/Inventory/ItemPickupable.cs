using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbtract
{
    [Header("Item Pickupable")]
    [SerializeField] private SphereCollider _sphereCollider;

    public static ItemCode String2ItemCode(string itemName)
    { // chuyển obj sang enum
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this._sphereCollider != null) return;
        this._sphereCollider = this.GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + "Loading trigger", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        this.itemController.ItemDespawn.DespawnObject();
    }

    public virtual void OnMouseDown()
    {
        Debug.Log(transform.parent.name);
        PlayerController.Instance.PlayerPickup.ItemPickup(this);
    }
}
