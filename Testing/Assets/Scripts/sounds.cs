using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class sounds : MonoBehaviour
{
    public AudioSource jumpSoundPrefab;
    public AudioSource popSoundPrefab;
    [SerializeField] Slider soundSlider;
    

    private void Start()
    {
        if (!PlayerPrefs.HasKey("gamemusicloop9"))
        {
            PlayerPrefs.SetFloat("gamemusicloop9", 1);
            Load();
        }
        else
        {
            Load();
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioSource jumpSoundInstance = Instantiate(jumpSoundPrefab); 
            jumpSoundInstance.Play(); 

            
            Destroy(jumpSoundInstance, 0.5f);
        }

        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = soundSlider.value;
        Save();
    }
    private void Load()
    {
        soundSlider.value = PlayerPrefs.GetFloat("gamemusicloop9");
    }

    private void Save()
    {
       PlayerPrefs.SetFloat("gamemusicloop9", soundSlider.value);
    }
}
