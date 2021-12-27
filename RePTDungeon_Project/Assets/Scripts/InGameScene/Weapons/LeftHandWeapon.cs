using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandWeapon : WeaponBase
{

    [SerializeField] GameObject leftHandWeapon;

    protected override void Start()
    {
        base.Start();
    }

    public override void EndAttack()
    {
        base.EndAttack();
        leftHandWeapon.SetActive(false);
    }

    public override void OnAttack()
    {
        base.OnAttack();
        leftHandWeapon.SetActive(true);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
