using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonWeapon : WeaponBase
{
    protected override void Start()
    {
        base.Start();
    }

    public override void OnAttack()
    {
        base.OnAttack();
    }

    public override void EndAttack()
    {
        base.EndAttack();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
