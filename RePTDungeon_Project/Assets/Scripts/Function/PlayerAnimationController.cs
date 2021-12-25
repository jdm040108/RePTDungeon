using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public void OnAttack()
    {
        player.OnAttack();
    }

    public void InitializeAnimation()
    {
        player.InitKind();
    }
}
