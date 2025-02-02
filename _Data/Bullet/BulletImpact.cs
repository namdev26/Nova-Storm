using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.04f;
        Debug.Log(transform.name + ": Loaded collider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = this.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": Loaded rigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletController.Shooter) return;
        
        this.bulletController.DamageSender.Send(other.transform);
        //this.CreateImpactFX(other);
    }

    // protected virtual void CreateImpactFX(Collider other)
    // {
    //     string fxName = this.GetImpactFX();
    //     Vector3 hitPos = transform.position;
    //     Quaternion hitRot = transform.rotation;
    //     Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //     fxImpact.gameObject.SetActive(true); 
    // }

    // protected virtual string GetImpactFX()
    // {
    //     return FXSpawner.impactOne;
    // }
}
