using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    //ayman
    //creating scriptfor ui
    //


    //variable for pause menu
    public static bool GameIspaused = false;
    public GameObject PauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIspaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
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
    //function for pause menu
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIspaused = false;
    }
    //function for pause menu
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIspaused= true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("LOADING GAME...");
    }

    //public void QuitGame()
    //{
    //    Debug.Log("QUITING GAME...");
    //    //Application.Quit();
    //}
}
