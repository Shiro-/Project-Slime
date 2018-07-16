using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused = false;

    public GameObject pauseMenu;

    //If used on mobile device, there will be a button for pausing
    public Button pauseButton;

    //Buttons on the pause menu itself
    public Button resumeButton;
    public Button returnToMainMenuButton;
    public Button quitButton;

    void Start()
    {
        Button pause = pauseButton.GetComponent<Button>();
        Button resume = resumeButton.GetComponent<Button>();
        Button returnToMainMenu = returnToMainMenuButton.GetComponent<Button>();
        Button quit = quitButton.GetComponent<Button>();

        //Used when we click on buttons
        pause.onClick.AddListener(PauseGame);
        resume.onClick.AddListener(ResumeGame);
        returnToMainMenu.onClick.AddListener(ReturnToMainMenu);
        quit.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //Reference for timescale https://docs.unity3d.com/ScriptReference/Time-timeScale.html
    void PauseGame()
    {
        Time.timeScale = 0f;
        SetPauseMenuActivity();
        SetPauseButtonActivity();
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        SetPauseMenuActivity();
        SetPauseButtonActivity();
        isPaused = false;
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.Find("StartController"));
        //When I add the buttons
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        //Close application
        Application.Quit();
    }

    //Hiding the menu itself
    void SetPauseMenuActivity()
    {
        if(isPaused)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }

    //Only for mobile, i think
    //Hide when the game is paused
    void SetPauseButtonActivity()
    {
        if(isPaused)
        {
            pauseButton.gameObject.SetActive(true);
        }
        else
        {
            pauseButton.gameObject.SetActive(false);
        }
    }
}
