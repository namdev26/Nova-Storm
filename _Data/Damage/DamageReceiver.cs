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
        this.Reborn();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadCollider();
        this.Refresh();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.26f;
        Debug.Log(transform.name + ": Loaded Collider", gameObject);
    }
    protected override void Refresh()
    {
        base.Refresh();
        this.isDead = false;
    }
    protected virtual void Reborn()
    {
        this.hp = this.maxHp;
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
