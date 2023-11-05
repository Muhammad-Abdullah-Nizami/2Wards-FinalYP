using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualscript : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Animator>().Play("sprint");
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2.5f, 0, 6);
            StartCoroutine(stoplanechD());
            //Vector3 desiredPosition = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }

        if (Input.GetKeyUp("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2.5f, 0, 6);
            StartCoroutine(stoplanechD());
            //Vector3 desiredPosition = new Vector3(transform.position.x+ 2.5f, transform.position.y, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }

    IEnumerator stoplanechD()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
        //Vector3 newPosition = new Vector3(2.5f, transform.position.y, transform.position.z);
        //transform.position = newPosition;

    }

    //IEnumerator stoplanechA()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
    //    //Vector3 newPosition = new Vector3(-2.5f, transform.position.y, transform.position.z);
    //    //transform.position = newPosition;

    //}
    void FixedUpdate()
    {
        //transform.position += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
