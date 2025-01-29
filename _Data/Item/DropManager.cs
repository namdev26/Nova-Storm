using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : NamMonoBehaviour
{
    private static DropManager _instance;
    public static DropManager Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.Instance == null) Debug.Log("Only DropManager");
        DropManager._instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.name);
    }
}
