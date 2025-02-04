using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
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
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Debug.Log(itemInventory.upgradeLevel);
        Debug.Log(itemInventory.itemProfile.itemName);
        // Debug.Log("Item Dropped");

        UnityEngine.Vector3 dropPos = transform.position;
        UnityEngine.Quaternion dropPot = transform.rotation;
        dropPos.x += 1;

        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, dropPot);
    }

}
