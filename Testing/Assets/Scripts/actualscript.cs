using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class actualscript : MonoBehaviour
{
    //private Player PlayerInstance;

    public static Vector3 astroposition;

    public float xSpeed = 8f;
    private float xMovement;
    public float jumpspeed = 10f;
    public float downaccel = 0.75f;

    public GameObject smokePrefab;


    private bool aKeyPressed = false;
    private bool dKeyPressed = false;
    public Animator theanimator;
    public Rigidbody bodyrigid;
    public Vector3 _velocity;

    void Start()
    {
        _velocity = new Vector3(0, 0, 8);
    }

    void Update()
    {
        astroposition=transform.position;
    }

    void FixedUpdate()
    {
        inputhandling();
        Move();
        jump();
        theanimator.SetTrigger("sprint");
        bodyrigid.velocity = _velocity;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }


    void jump()
    {
        if (IsGrounded())
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

    void IsObstacleInFront()
    {
        float rayLength = 10.0f;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            
            if (hit.collider.CompareTag("obstacle"))
            {
                
                Destroy(hit.collider.gameObject);
                GameObject smoke = Instantiate(smokePrefab, hit.point, Quaternion.identity);

                Destroy(smoke, 3.0f);
            }

        }

    }

    void IsObstacleMoveable()
    {
        float rayLength = 10.0f;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            if (hit.collider.CompareTag("moveleftobstacle"))
            {
                MoveObstacle(hit, -2.5f);
            }

        }
    }

    void MoveObstacle(RaycastHit hit, float moveAmount)
    {
        // Get the obstacle's current position
        Vector3 obstaclePosition = hit.collider.transform.position;

        // Calculate the new position based on the movement amount
        Vector3 newPosition = new Vector3(obstaclePosition.x + moveAmount, obstaclePosition.y, obstaclePosition.z);

        // Move the obstacle to the new position
        hit.collider.transform.position = newPosition;
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

        if (Input.GetButtonDown("f"))
        {
            IsObstacleInFront();
        }

        if (Input.GetButtonDown("e"))
        {
            IsObstacleMoveable();
        }

    }

    
    //USE THIS TO TURN HEALTH BACK TO MAXIMUM ON COLLISION TRIGGER WITH YOUR OBJECT AND DESTROY THE GAMEOBJECT
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Tank"))
    //    {
    //        PlayerInstance.MaxHealth();
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("moveleftobstacle"))
        {
            Debug.Log("Collision!");
            _velocity = new Vector3(0, 0, 0);
            //theanimator.SetTrigger("rightstep");
            Invoke("Loadgameover", 1f);
        }
    }
    public void Loadgameover()
    {
        SceneManager.LoadScene("game over");
        _velocity = new Vector3(0, 0, 0);
    }

}