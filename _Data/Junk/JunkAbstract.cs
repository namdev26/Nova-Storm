using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbtract : NamMonoBehaviour
{
    [SerializeField] protected JunkController junkController;
    public JunkController JunkController { get => junkController; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkController();
    }

    private void LoadJunkController()
    {
        if (this.JunkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": Load Controller " + gameObject);
    }
}
