using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject resumePanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resumee();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resumee()
    {
        
        resumePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }
     void Pause()
        {    
    
        resumePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Efe");
    }

}



        
