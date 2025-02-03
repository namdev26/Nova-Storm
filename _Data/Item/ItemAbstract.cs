using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbtract : NamMonoBehaviour
{
    [SerializeField] protected ItemController itemController;
    public ItemController ItemController => itemController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemController();
    }

    private void LoadItemController()
    {
        if (this.itemController != null) return;
        this.itemController = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": Load Item Controller " + gameObject);
    }
}
