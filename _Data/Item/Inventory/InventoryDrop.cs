using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]
    // [SerializeField] protected int maxLevel = 10;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);
    }

    private void Test()
    {
        UnityEngine.Vector3 dropPos = transform.position;
        dropPos.x += 1;
        this.DropItemIndex(0, dropPos, transform.rotation);
    }

    protected virtual void DropItemIndex(int itemIndex, UnityEngine.Vector3 dropPos, UnityEngine.Quaternion dropRot)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
    }

}
