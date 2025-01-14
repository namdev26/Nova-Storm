using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;

    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        // Lấy vị trí của chuột đang click vào game world
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_x = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_x);  // Xoay theo chiều x để tàu đảo hướng đi
    }

    protected virtual void Moving()
    {
        // Di chuyển tàu đến vị trí mà người dùng đã click chuột
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed); // nội suy với bắt đầu , kết thúc, và tỉ lệ nội suy
        transform.parent.position = newPos;
    }
}
