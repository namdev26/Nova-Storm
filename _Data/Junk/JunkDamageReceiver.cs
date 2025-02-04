using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkController();
        this.LoadCollider();
        this.Reborn();
    }
    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": Loaded junk controller", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();// cài hiệu ứng chết
        this.OnDeadDrop();
        this.junkController.JunkDespawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        UnityEngine.Vector3 dropPos = transform.position;
        UnityEngine.Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkController.JunkSO.dropList, dropPos, dropRot);
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
        this.maxHp = this.junkController.JunkSO.hpMax;
        base.Reborn();
        //Debug.LogWarning("Reborn" , gameObject);
    }
}
