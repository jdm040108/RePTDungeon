using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    protected float Hp;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Damaged(float _damage, float drag /*�з����� ����*/)
    {
        Hp -= _damage;
        //damage effect
    }
}
