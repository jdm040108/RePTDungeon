using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : WeaponBase
{

    [SerializeField] ShotgunBullet bullet;
    ShotgunBullet this_bullet;

    protected override void Start()
    {
        base.Start();
    }

    public override void EndAttack()
    {
        base.EndAttack();
        Destroy(this_bullet.gameObject);
    }

    public override void OnAttack()
    {
        base.OnAttack();
        ShotgunBullet bullet_temp = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet_temp.InitBullet(0, 0, Damage, 0);
        this_bullet = bullet_temp;
    }
}
