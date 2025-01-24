using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class DamageReceiver : NamMonoBehaviour
{
    [SerializeField] protected float hp = 1;
    [SerializeField] protected float maxHp = 1;
    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.hp = this.maxHp;
    }

    public virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }
}
