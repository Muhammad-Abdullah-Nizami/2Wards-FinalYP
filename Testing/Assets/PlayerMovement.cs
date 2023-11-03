using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator playerAnim;
    public Rigidbody playerRigid;
    
    public Transform playerTrans;

    void Start()
    {
        GetComponent<Animator>().Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
