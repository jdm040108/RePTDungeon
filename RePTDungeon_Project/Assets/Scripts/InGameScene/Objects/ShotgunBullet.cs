using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{

    float damage;
    float drag;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InitBullet(float speed, float degree, float _damage, float _drag)
    {
        damage = _damage;
        drag = _drag;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().Damaged(damage, drag);
        }
    }
}
