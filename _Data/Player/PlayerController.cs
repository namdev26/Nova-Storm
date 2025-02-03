using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NamMonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance => instance;
    [SerializeField] protected ShipController currentShip;
    public ShipController CurrentShip => currentShip;
    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerController.instance != null) Debug.Log("Only one playerController");
        PlayerController.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + "Loading player pickup ", gameObject);
    }
}
