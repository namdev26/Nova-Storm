using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistane : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponent()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": :oadCamera");
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
