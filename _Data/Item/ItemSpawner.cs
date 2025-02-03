using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner _instance;
    public static ItemSpawner Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.Instance == null) Debug.Log("Only DropManager");
        ItemSpawner._instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        itemDrop.gameObject.SetActive(true);
    }
}
