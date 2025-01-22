using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class GameController : NamMonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get => instance; }
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }
    protected override void Awake()
    {
        base.Awake();
        if (GameController.instance != null) Debug.LogError("Only one GameController");
        GameController.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameController.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": Loaded camera " + gameObject);
    }
}
