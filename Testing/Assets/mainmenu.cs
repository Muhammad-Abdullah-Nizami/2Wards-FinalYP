using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    //ayman
    //creating scriptfor ui
    //


    private ScoreManager scoremanagerscriptinstance;
    private actualscript getting_calorie_count;
    //variable for pause menu
    public static bool GameIspaused = false;
    public GameObject PauseMenuUI;
    //variable to show highscore on gameover ui
    public Text ScoreCount;
    public Text HighScoreCount;
    public Text CaloriesCount;
    public Animator mainMenuAnimator;

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
        if (ScoreManager.GameHasEnded)
        {
            for (int i = 0; i < 1; i++)
            {
                ShowScoreOnGameOver();
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
        mainMenuAnimator.SetTrigger("moonanimation");
        Debug.Log("LOADING GAME...");
    }

    //public void QuitGame()
    //{
    //    Debug.Log("QUITING GAME...");
    //    //Application.Quit();
    //}

    private void ShowScoreOnGameOver()
    {
        //Debug.Log("Score::" + ScoreManager.CountedScoretoDisplay);
        //ScoreCount.text = "Your Score: " +ScoreManager.CountedScoretoDisplay;
        if (ScoreCount != null)
        {
            ScoreCount.text = "Your Score: " + ScoreManager.CountedScoretoDisplay;
        }
        //HighScoreCount.text = "HIGH SCORE " + Mathf.RoundToInt(ScoreManager.HighscoretoDisplay);
        if (HighScoreCount != null)
        {
            HighScoreCount.text = "HIGH SCORE: " + Mathf.RoundToInt(ScoreManager.HighscoretoDisplay);
        }

        if (CaloriesCount != null)
        {
            CaloriesCount.text = "Calories:  " + actualscript.calculate;
        }

    }
   

        //void functionbangaya()
        //{
        //    GameObject scoremanagerscriptObject = GameObject.Find("Score");
        //    if (scoremanagerscriptObject != null)
        //    {
        //        scoremanagerscriptinstance = scoremanagerscriptObject.GetComponent<ScoreManager>();


        //        if (scoremanagerscriptinstance == null)
        //        {
        //            Debug.LogError("scoremanagerscript component not found on the specified GameObject.");
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogError("GameObject with scoremanagerscript not found.");
        //    }


        //}


    }
