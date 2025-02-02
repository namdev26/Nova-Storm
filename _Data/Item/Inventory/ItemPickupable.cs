using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : NamMonoBehaviour
{
    [SerializeField] private SphereCollider _sphereCollider;

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
        this._sphereCollider.radius = 0.15f;
        Debug.Log(transform.name + "Loading trigger", gameObject);
    }
}
