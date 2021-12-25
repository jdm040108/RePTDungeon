using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : WeaponBase
{
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
            other.GetComponent<EnemyBase>().Damaged(Damage, Drag);
            Player.Hp += Damage;
        }
    }
}
