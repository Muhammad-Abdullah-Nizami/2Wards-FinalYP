using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.z<actualscript.astroposition.z-40)
        {
            Destroy(gameObject);
        }
    }
}
