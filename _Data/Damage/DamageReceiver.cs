using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : NamMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int maxHp = 1;
    [SerializeField] protected bool isDead = false;
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadCollider();
        this.Reborn();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.26f;
        Debug.Log(transform.name + ": Loaded Collider", gameObject);
    }
    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
        if (this.IsDead()) return;
        this.hp += add;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.IsDead()) return;
        this.hp -= deduct;
        if (this.hp <= 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        // Implement death logic here
        Debug.Log(transform.name + ": Dead", gameObject);
    }
}
