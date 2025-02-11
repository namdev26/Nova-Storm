using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : NamMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;

    protected float distance = 0f;
    protected float minDistance = 1f;
    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
        this.Moving();
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
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance <= this.minDistance) return;// Nếu đã gần đến điểm đích và tàu đã đến ch�� đích
        // Di chuyển tàu đến vị trí mà người dùng đã click chuột
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed); // nội suy với bắt đầu , kết thúc, và tỉ lệ nội suy
        transform.parent.position = newPos;
    }
}
