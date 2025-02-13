using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    protected static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.Instance == null) //Debug.Log("Only DropManager");
        ItemDropSpawner._instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        if (dropList.Count < 1) return; //
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);

        ItemController itemController = itemDrop.GetComponent<ItemController>();
        itemController.SetItemInventory(itemInventory);
        return itemDrop;
    }
}
