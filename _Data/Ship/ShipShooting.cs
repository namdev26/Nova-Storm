using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 5f;

    void Update()
    {
        this.IsShooting();
    }

    void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.rotation;
        //Transform newBullet =  Instantiate(this.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        newBullet.gameObject.SetActive(true);
        if (newBullet != null) return;

        newBullet.gameObject.SetActive(true);
        Debug.Log("Is Shooting");
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
