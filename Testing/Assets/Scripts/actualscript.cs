using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class actualscript : MonoBehaviour
{
    public float xSpeed = 8f;
    private float xMovement;
    public float jumpspeed = 10f;
    public float downaccel = 0.75f;
    
    

    private bool aKeyPressed = false;
    private bool dKeyPressed = false;
    public Animator theanimator;
    public Rigidbody bodyrigid;
    public Vector3 _velocity;

    void Start()
    {
        _velocity = new Vector3 (0,0, 6);
    }

    void Update()
    {
        
    }
   
    void FixedUpdate()
    {
        inputhandling();
        Move();
        jump();
        theanimator.SetTrigger("sprint");
        bodyrigid.velocity= _velocity;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }

    void jump()
    {
        if ( IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                _velocity.y = jumpspeed;
                theanimator.SetTrigger("jump");
            }
            else
            {
                _velocity.y = 0f;
            }
        }
        else
        {
            _velocity.y -= downaccel;
        }
    }
    bool IsGrounded()
    {
        float rayLength = 0.1f;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            return true;
        }

        return false;
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

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("obstacle"))
        //{
        Debug.Log("Collision!");
        Invoke("Loadgameover", 1f);
        //}
    }
    void Loadgameover()
    {
        SceneManager.LoadScene("game over");
        _velocity = new Vector3(0, 0, 0);
    }

}
