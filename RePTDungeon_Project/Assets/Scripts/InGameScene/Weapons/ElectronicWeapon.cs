using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElectronicType
{
    Charge,
    Use
}

public class ElectronicWeapon : WeaponBase
{
    public int chargeAmount;
    [SerializeField] ElectronicType electronicType;

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
            switch (electronicType)
            {
                case ElectronicType.Charge:
                    Player.Charge += chargeAmount;
                    other.GetComponent<EnemyBase>().Damaged(Damage, Drag);
                    break;
                case ElectronicType.Use:
                    Player.Charge = 0;
                    other.GetComponent<EnemyBase>().Damaged(Damage * Player.Charge, Drag);
                    break;
                default:
                    break;
            }
        }
    }
}
