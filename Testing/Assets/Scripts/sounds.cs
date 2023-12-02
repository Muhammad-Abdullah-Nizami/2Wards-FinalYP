using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioSource jumpSoundPrefab;
    public AudioSource popSoundPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource jumpSoundInstance = Instantiate(jumpSoundPrefab); 
            jumpSoundInstance.Play(); 

            
            Destroy(jumpSoundInstance, 0.5f);
        }

        
    }
}
