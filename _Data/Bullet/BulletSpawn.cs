using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : DespawnByDistane
{
    protected override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
