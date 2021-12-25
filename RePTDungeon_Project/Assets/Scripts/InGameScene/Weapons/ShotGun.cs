using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : WeaponBase
{
    [SerializeField] ShotgunBullet bullets;
    [SerializeField] int bulletCount;

    List<ShotgunBullet> now_bullet = new List<ShotgunBullet>();

    public override void OnAttack()
    {
        base.OnAttack();

        for (int i = 0; i < bulletCount; i++)
        {
            ShotgunBullet tempBullet = Instantiate(bullets, transform.position, Quaternion.identity);
            now_bullet.Add(tempBullet);
        }
    }

    public override void EndAttack()
    {
        base.EndAttack();
        for (int i = 0; i < now_bullet.Count; i++)
        {
            Destroy(now_bullet[i].gameObject);
        }
        now_bullet.Clear();
    }
}
