using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    //public GameObject player;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if(gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        if(LevelControl.thisInstance && LevelControl.thisInstance.GetPlayer()) LevelControl.thisInstance.GetPlayer().GetComponent<CharacterController>().enabled = true; // Turn on the component
        Debug.Log("Resume Game");
    }

    void Pause()
    {

        gameIsPaused = true;
        if (LevelControl.thisInstance && LevelControl.thisInstance.GetPlayer()) LevelControl.thisInstance.GetPlayer().GetComponent<CharacterController>().enabled = false; // Turn off the component
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Debug.Log("Paused Game");
    }

       public void QuitGame()
    {
        Application.Quit();
    }
}
