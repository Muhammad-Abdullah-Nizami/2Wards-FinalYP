using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class actualscript : MonoBehaviour
{
    //private Player PlayerInstance;
    public AudioSource popSoundPrefab;
    public static Vector3 astroposition;

    public float xSpeed = 8f;
    private float xMovement;
    public float jumpspeed = 10f;
    public float downaccel = 0.75f;

    public GameObject smokePrefab;
    public GameObject SpeedEffectPrefab;



    private bool aKeyPressed = false;
    private bool dKeyPressed = false;
    public Animator theanimator;
    public Rigidbody bodyrigid;
    public Vector3 _velocity;

    public int abilitycounter = 0;
    public int coinscounter = 0;
    private float timer = 0.0f;
    private float speed = 8.0f;


    //getting script

    public ParticleSystem abeffect;
    public bool spacebuttonpressed = false;
    public bool jumpges;

    private GestureListener gesturelistenerscriptinstance;
    



    void Start()
    {
        ScoreManager.GameHasEnded = false;
        FindGLScript();
        _velocity = new Vector3(0, 0, 8);

    }

    void FindGLScript()
    {
        GameObject gesturelistenerObject = GameObject.Find("KCamera");
        if (gesturelistenerObject != null)
        {
            gesturelistenerscriptinstance = gesturelistenerObject.GetComponent<GestureListener>();

            if (gesturelistenerscriptinstance == null)
            {
                Debug.LogError("gesturelistenerscript component not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with gesturelistenerscript not found.");
        }
    }

    public void counterincrease()
    {
        abilitycounter++;
        Debug.Log("Ability counter icreased");
        Debug.Log(abilitycounter);
    }

    public void Coincounterincrease()
    {
        coinscounter++;
        Debug.Log("Coin counter icreased");
        Debug.Log(coinscounter);
    }


    void Update()
    {
        astroposition=transform.position;
    }

    void slowspeedinc()
    {
        timer += Time.deltaTime;

        // Check if the acceleration interval has passed
        if (timer >= 15)
        {
            // Increase speed by 0.5
            speed += 0.5f;

            // Reset the timer
            timer = 0.0f;

            // Update the velocity with the new speed
            _velocity = new Vector3(0, 0, speed);

            Debug.Log("Speed Increased!");
        }
    }

    void FixedUpdate()
    {
        inputhandling();
        Move();
        //jump();
        theanimator.SetTrigger("sprint");
        slowspeedinc();
        bodyrigid.velocity = _velocity;

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }


    //void jump()
    //{
    //    if (IsGrounded())
    //    {
    //        if (Input.GetButtonDown("Jump"))
    //        {
    //            _velocity.y = jumpspeed;
    //            theanimator.SetTrigger("jump");
    //        }
    //        else
    //        {
    //            _velocity.y = 0f;
    //        }
    //    }
    //    else
    //    {
    //        _velocity.y -= downaccel;
    //    }
    //}
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
        float rayLength = 15.0f;
        RaycastHit hit;
        Vector3 raycastOffset = new Vector3(0, -0.5f, 0);

        if (Physics.Raycast(transform.position + raycastOffset, transform.forward, out hit, rayLength))
        {
            
            if (hit.collider.CompareTag("obstacle"))
            {
                
                Destroy(hit.collider.gameObject);
                AudioSource popSoundInstance = Instantiate(popSoundPrefab);
                popSoundInstance.Play();
                Destroy(popSoundInstance, 0.5f);
                GameObject smoke = Instantiate(smokePrefab, hit.point, Quaternion.identity);

                Destroy(smoke, 3.0f);
            }

        }

    }

    void IsObstacleMoveable()
    {
        float rayLength = 15.0f;
        RaycastHit hit;
        Vector3 castOffset = new Vector3(0, -0.5f, 0);

        if (Physics.Raycast(transform.position + castOffset, transform.forward, out hit, rayLength))
        {
            if (hit.collider.CompareTag("moveleftobstacle"))
            {
                MoveObstacle(hit, 100.5f);

                GameObject SpeedEffect = Instantiate(SpeedEffectPrefab, hit.point, SpeedEffectPrefab.transform.rotation);
                Destroy(SpeedEffect, 0.5f);
            }
        }
    }

    void MoveObstacle(RaycastHit hit, float moveAmount)
    {
        // Get the obstacle's current position
        Vector3 obstaclePosition = hit.collider.transform.position;

        // Calculate the target position based on the movement amount
        Vector3 targetPosition = new Vector3(obstaclePosition.x, obstaclePosition.y + moveAmount, obstaclePosition.z);

        // Move the obstacle towards the target position smoothly
        float moveSpeed = 5.0f; // Adjust this value as needed
        hit.collider.transform.position = Vector3.MoveTowards(obstaclePosition, targetPosition, moveSpeed * Time.deltaTime);
    }



    //original
    //void IsObstacleMoveable()
    //{
    //    float rayLength = 15.0f;
    //    RaycastHit hit;
    //    Vector3 castOffset = new Vector3(0, -0.5f, 0);

    //    if (Physics.Raycast(transform.position+ castOffset, transform.forward, out hit, rayLength))
    //    {
    //        if (hit.collider.CompareTag("moveleftobstacle"))
    //        {
    //            MoveObstacle(hit, 10.5f);

    //            GameObject SpeedEffect = Instantiate(SpeedEffectPrefab, hit.point, SpeedEffectPrefab.transform.rotation);
    //            Destroy(SpeedEffect, 0.5f);
    //        }

    //    }
    //}

    void takeoff()
    {
        float rayLength = 15.0f;
        RaycastHit hit;
        

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            if (hit.collider.CompareTag("moveleftobstacle"))
            {
                Animator animator = GetComponent<Animator>();

                // Check if the Animator component is not null
                if (animator != null)
                {
                    // Play the "takeoff" animation clip
                    animator.Play("takeoff");
                    Debug.LogWarning("playing takeoff");

                }
                else
                {
                    // Log a warning if Animator component is not found
                    Debug.LogWarning("Animator component not found on the GameObject.");
                }
                //MoveObstacle(hit, -2.5f); 

                //GameObject SpeedEffect = Instantiate(SpeedEffectPrefab, hit.point, SpeedEffectPrefab.transform.rotation);
                //Destroy(SpeedEffect, 0.5f);
            }

        }
    }

    //original move obstacle
    //void MoveObstacle(RaycastHit hit, float moveAmount)
    //{
    //    // Get the obstacle's current position
    //    Vector3 obstaclePosition = hit.collider.transform.position;

    //    // Calculate the new position based on the movement amount
    //    //Vector3 newPosition = new Vector3(obstaclePosition.x + moveAmount, obstaclePosition.y, obstaclePosition.z);
    //    Vector3 newPosition = new Vector3(obstaclePosition.x, obstaclePosition.y + moveAmount, obstaclePosition.z);

    //    // Move the obstacle to the new position
    //    hit.collider.transform.position = newPosition;
    //}

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

        if (Input.GetButtonDown("f") || gesturelistenerscriptinstance.IsSwipeUp())
        {
            if (abilitycounter>0)
            {
                IsObstacleInFront();
                abilitycounter--;
                Debug.Log("after pressing F "+ abilitycounter);

            }

        }

        if (Input.GetButtonDown("e"))
        {

            if (abilitycounter > 0)
            {
                //takeoff();
                IsObstacleMoveable();
                abilitycounter--;
                Debug.Log("after pressing E " + abilitycounter);

            }

        }

        if (Input.GetButtonDown("s"))
        {
            theanimator.SetTrigger("roll");
        }

        if (IsGrounded())
        {
            if (SpacePressed() || jumpges)
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

     bool SpacePressed()
    {
        if (Input.GetButtonDown("Jump") || gesturelistenerscriptinstance.IsJump())
        {
            return true;
        }
        return false;
    }

    public void MoveLeft()
    {
        if (xMovement == 0f)
        {
            xMovement = -2.5f;
        }
        else if (xMovement == 2.5f)
        {
            xMovement = 0f;
        }

        theanimator.SetTrigger("leftstep");
        theanimator.SetTrigger("sprint");
    }

    public void MoveRight()
    {
        if (xMovement == 0f)
        {
            xMovement = 2.5f;
        }
        else if (xMovement == -2.5f)
        {
            xMovement = 0f;
        }

        theanimator.SetTrigger("rightstep");
        theanimator.SetTrigger("sprint");
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
            ScoreManager.GameHasEnded = true;
            Debug.Log("Collision!");
            _velocity = new Vector3(0, 0, 0);
            theanimator.SetTrigger("fall");
            Invoke("Loadgameover", 2f);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("O2 tank"))
        {
            if (abeffect != null)
            {
                abeffect.Play();
            }
        }
    }
    public void Loadgameover()
    {
        SceneManager.LoadScene("game over");
        _velocity = new Vector3(0, 0, 0);
    }

}