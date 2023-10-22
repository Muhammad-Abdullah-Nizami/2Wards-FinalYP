using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; 

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
