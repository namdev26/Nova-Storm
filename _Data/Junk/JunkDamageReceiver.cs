using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkController();
        this.LoadCollider();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": Loaded junk controller", gameObject);
    }

    protected override void OnDead()
    {
        this.junkController.JunkDespawn.DespawnObject();
    }
}
