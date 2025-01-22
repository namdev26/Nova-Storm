using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : NamMonoBehaviour
{
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {   
        Transform ranPoint = this.junkController.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = this.transform.rotation;
        Transform obj = this.junkController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
