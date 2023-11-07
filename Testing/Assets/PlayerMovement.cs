using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator playerAnim;
    public Rigidbody playerRigid;
    public Transform playerTrans;
    public float xSpeed = 10f;
    private float xMovement;
    

    void Start()
    {
        GetComponent<Animator>().Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
              
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
            transform.position = Vector3.MoveTowards (transform.position, new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime*xSpeed);
    }

    void inputhandling()
    {
        if (Input.GetKeyDown (KeyCode.D))
        {
            if (xMovement== 0)
            {
                xMovement = 2.5f;
            }
            else if (xMovement == -2.5f)
            {
                xMovement = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (xMovement == 0)
            {
                xMovement = -2.5f;
            }
            else if (xMovement == 2.5f)
            {
                xMovement = 0f;
            }
        }

    }
}
