using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : NamMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
