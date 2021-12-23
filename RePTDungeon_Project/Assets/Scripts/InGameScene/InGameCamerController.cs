using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCamerController : MonoBehaviour
{

    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
