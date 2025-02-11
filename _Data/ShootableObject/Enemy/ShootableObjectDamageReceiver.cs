using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectController shootableObjectController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootableObjectController();
        this.LoadCollider();
        this.Reborn();
    }
    protected virtual void LoadShootableObjectController()
    {
        if (this.shootableObjectController != null) return;
        this.shootableObjectController = transform.parent.GetComponent<ShootableObjectController>();
        Debug.Log(transform.name + ": Loaded Shootable Object controller", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();// cài hiệu ứng chết
        this.OnDeadDrop();
        this.shootableObjectController.Despawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        UnityEngine.Vector3 dropPos = transform.position;
        UnityEngine.Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectController.ShootableObjectSO.dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetFXDeadName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetFXDeadName()
    {
        return FXSpawner.smokeOne;
    }

    public override void Reborn()
    {
        this.hpMax = this.shootableObjectController.ShootableObjectSO.hpMax;
        base.Reborn();
        //Debug.LogWarning("Reborn" , gameObject);
    }
}
