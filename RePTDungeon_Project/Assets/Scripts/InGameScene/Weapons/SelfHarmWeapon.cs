using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHarmWeapon : WeaponBase
{
    public float harmAmount;
    public int harmCount;

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
        Player.SelfHarmActive(harmCount, harmAmount);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

}
