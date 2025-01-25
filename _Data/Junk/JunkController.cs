using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : NamMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadJunkDespawn();
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn!= null) return;
        this.junkDespawn = transform.parent.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": Load JunkDespawn", gameObject);   // Implement your junk despawn logic here
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);   // Implement your model loading logic here
    }
}
