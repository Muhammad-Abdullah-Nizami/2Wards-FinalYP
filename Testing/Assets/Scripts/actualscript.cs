using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualscript : MonoBehaviour
{
    public float xSpeed = 8f;
    private float xMovement;

    private bool aKeyPressed = false;
    private bool dKeyPressed = false;
    public Animator theanimator;

    void Start()
    {
        //GetComponent<Animator>().Play("sprint");
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
    }

    void Update()
    {
        
    }
   
    void FixedUpdate()
    {
        inputhandling();
        Move();
        theanimator.SetTrigger("sprint");
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
            theanimator.SetTrigger("rightstep");

            if (xMovement == 0)
            {
                xMovement = 2.5f;
            }
            else if (xMovement == -2.5f)
            {
                xMovement = 0f;
            }
            theanimator.SetTrigger("sprint");

        }

        if (Input.GetKeyUp("d"))
        {
            dKeyPressed = false;
            theanimator.SetTrigger("sprint");

        }

        if (Input.GetKeyDown("a") && !aKeyPressed)
        {
            
            aKeyPressed = true;
            theanimator.SetTrigger("leftstep");
            if (xMovement == 0)
            {
                xMovement = -2.5f;
                

            }
            else if (xMovement == 2.5f)
            {
                xMovement = 0f;
                

            }
            theanimator.SetTrigger("sprint");
        }

        if (Input.GetKeyUp("a"))
        {
            aKeyPressed = false;
            theanimator.SetTrigger("sprint");

        }

    }
}
