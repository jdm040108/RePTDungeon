using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSword : WeaponBase
{

    public float dotDeal_damage;
    public int dotDeal_count;

    protected override void Start()
    {
        base.Start();
    }

    public override void EndAttack()
    {
        base.EndAttack();
    }

    public override void OnAttack()
    {
        base.OnAttack();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (IsDamageAble && other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().Damaged(Damage * Player.buff, Drag);
            other.GetComponent<EnemyBase>().StartDotDeal(dotDeal_count, dotDeal_damage);
        }
    }
}
