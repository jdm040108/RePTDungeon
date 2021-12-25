using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected PlayerController Player;
    protected Collider DamageCollider;

    public bool IsDamageAble;
    public float Damage;
    public float Drag;


    protected virtual void Start()
    {
        DamageCollider = GetComponent<Collider>();
        Player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    public virtual void OnAttack()
    {
        IsDamageAble = true;
    }

    public virtual void EndAttack()
    {
        IsDamageAble = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (IsDamageAble && other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().Damaged(Damage, Drag);
        }
    }
}
