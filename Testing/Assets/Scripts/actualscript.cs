using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualscript : MonoBehaviour
{
    public float xSpeed = 10f;
    private float xMovement;

    private bool aKeyPressed = false;
    private bool dKeyPressed = false;

    void Start()
    {
        GetComponent<Animator>().Play("sprint");
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
    }

    void Update()
    {
        
    }
   
    void FixedUpdate()
    {
        inputhandling();
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }

    void inputhandling()
    {
        if (Input.GetKeyDown("d") && !dKeyPressed)
        {
            dKeyPressed = true;
            if (xMovement == 0)
            {
                xMovement = 2.5f;
            }
            else if (xMovement == -2.5f)
            {
                xMovement = 0f;
            }
        }

        if (Input.GetKeyUp("d"))
        {
            dKeyPressed = false;
        }

        if (Input.GetKeyDown("a") && !aKeyPressed)
        {
            aKeyPressed = true;
            if (xMovement == 0)
            {
                xMovement = -2.5f;
            }
            else if (xMovement == 2.5f)
            {
                xMovement = 0f;
            }
        }

        if (Input.GetKeyUp("a"))
        {
            aKeyPressed = false;
        }

    }
}
