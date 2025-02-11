using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ShipMovement
{
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected virtual void GetMousePosition()
    {
        // Lấy vị trí của chuột đang click vào game world
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
}
