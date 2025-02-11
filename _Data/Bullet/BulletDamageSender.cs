using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamSender : DamageSender
{
    [SerializeField] protected BulletController bulletController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;

        this.CreateImpactFX(hitPos, hitRot);
        //this.CreateTextDamageFX(hitPos);
        this.DestroyBullet();
    }

    protected virtual void CreateImpactFX(Vector3 hitPos, Quaternion hitRot)
    {
        string fxName = this.GetImpactFX();
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected override string GetImpactFX()
    {
        return FXSpawner.impactOne;
    }

    protected virtual void DestroyBullet()
    {
        this.bulletController.BulletDespawn.DespawnObject();
    }
}
