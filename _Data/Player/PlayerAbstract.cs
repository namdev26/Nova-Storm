using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : NamMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerController playerController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + " loaded PlayerController", gameObject);
    }
}
