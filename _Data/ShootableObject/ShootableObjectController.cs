using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectController : NamMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO => shootableObjectSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/"+ this.GetObjectTypeString() + "/" + transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        //Debug.Log(transform.name + ": LoadJunkSO" + resPath, gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": Load Despawn", gameObject);   // Implement your junk despawn logic here
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);   // Implement your model loading logic here
    }

    protected abstract string GetObjectTypeString();
}
