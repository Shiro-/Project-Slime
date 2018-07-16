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
        //When I add the buttons
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        //Close application
        Application.Quit();
    }

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
    void SetPauseButtonActivity()
    {
        if(isPaused)
        {
            pauseButton.gameObject.SetActive(false);
        }
        else
        {
            pauseButton.gameObject.SetActive(true);
        }
    }
}
