using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioSource jumpSoundPrefab; // Reference to the jump sound prefab

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource jumpSoundInstance = Instantiate(jumpSoundPrefab); // Create a new AudioSource instance
            jumpSoundInstance.Play(); // Play the sound effect

            // Destroy the AudioSource after a short delay to avoid memory leaks
            Destroy(jumpSoundInstance, 0.5f);
        }
    }
}
