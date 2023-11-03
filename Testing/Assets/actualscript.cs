using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualscript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    void Start()
    {
        GetComponent<Animator>().Play("sprint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
