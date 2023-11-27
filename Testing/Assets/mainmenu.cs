using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    //ayman
    //creating scriptfor ui   
    public void playgame()
    {
        Invoke("Loadgame", 0.1f);

    }

    public void Quitgame()
    {
        Debug.Log("QUIT!!!!");
        Application.Quit();
            
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Loadgame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
