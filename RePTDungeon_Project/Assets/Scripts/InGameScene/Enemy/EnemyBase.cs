using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    protected float Hp;

    public float dotDeal_Delay;
    float curDelay;

    bool dotDeal_available;
    float dotDeal_damage;
    int dotDeal_count;

    void Start()
    {
        
    }

    void Update()
    {
        
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
        //damage effect
    }

    public void StartDotDeal(int count, float damage)
    {
        dotDeal_available = true;
        dotDeal_damage = damage;
        dotDeal_count = count;
    }
}
