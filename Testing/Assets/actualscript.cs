using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("sprint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
