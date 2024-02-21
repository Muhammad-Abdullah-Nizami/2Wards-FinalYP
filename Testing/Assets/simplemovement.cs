using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Rigidbody bodyrigid;
    public float speed = 8f; // Speed of movement along the x-axis
    public float constantVelocityZ = 8f; // Constant velocity along the z-axis

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate normalized movement direction along the x-axis
        Vector3 movement = new Vector3(horizontalInput, 0, 0).normalized * speed * Time.deltaTime;

        // Add constant velocity along the z-axis
        movement.z = constantVelocityZ * Time.deltaTime;

        // Move the Rigidbody
        bodyrigid.MovePosition(transform.position + movement);
    }
}
