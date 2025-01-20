using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : NamMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

}
