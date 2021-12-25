using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 reactVec;

    float Knockback;
    static bool isHit;

    protected float Hp;

    public float dotDeal_Delay;
    float curDelay;

    bool dotDeal_available;
    float dotDeal_damage;
    int dotDeal_count;

    void Start()
    {
        isHit = false;
    }

    void Update()
    {
       if(isHit==true)
        {
            reactVec = reactVec.normalized;
            reactVec += Vector3.back;
            rigid.AddRelativeForce(reactVec * Knockback, ForceMode.Impulse);
            isHit = false;
        }
    }

    void DotDealLogic()
    {
        if(dotDeal_available)
        {
            if(curDelay >= dotDeal_Delay)
            {
                Hp -= dotDeal_damage;
                curDelay = 0;
                dotDeal_count--;
            }
            else
            {
                curDelay += Time.deltaTime;
            }

            if(dotDeal_count <= 0)
            {
                dotDeal_available = false;
            }
        }
    }

    public void Damaged(float _damage, float drag /*밀려나는 정도*/)
    {
        Hp -= _damage;
        if (drag != 0)
        {
            Knockback = drag;
            isHit = true;
        }
        //damage effect
    }

    public void StartDotDeal(int count, float damage)
    {
        dotDeal_available = true;
        dotDeal_damage = damage;
        dotDeal_count = count;
    }
}
