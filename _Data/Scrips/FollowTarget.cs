using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : NamMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 5f;

    protected virtual void FixedUpdate()
    {
        this.Follwing();
    }

    protected virtual void Follwing()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * this.speed);
    }

}
