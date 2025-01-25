using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletController bulletController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBullerController();
    }

    protected virtual void LoadBullerController()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": loading bullet controller", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletController.BulletDespawn.DespawnObject();
    }
}
