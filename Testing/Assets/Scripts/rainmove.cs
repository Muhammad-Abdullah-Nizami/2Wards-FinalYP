using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainmove : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
