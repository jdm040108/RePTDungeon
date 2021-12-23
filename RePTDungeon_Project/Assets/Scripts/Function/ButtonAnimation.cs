using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartEvent()
    {
        anim.SetBool("IsEvent", true);
    }

    public void EndEvent()
    {
        anim.SetBool("IsEvent", false);
    }
}
