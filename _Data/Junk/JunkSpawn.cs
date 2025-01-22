using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawn : DespawnByDistane
{
    protected override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 25f;
    }
}
