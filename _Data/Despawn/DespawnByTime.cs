using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    //chua dung
    protected override bool CanDespawn()
    {
        return false;
    }
}
