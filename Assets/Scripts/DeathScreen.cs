using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    //Death Stuff
    public GameObject deathScreen;
    public Button retryButton;
    public Button returnToMainMenuButton;
    public Button quitButton;

    bool isPlayerDead;



    void Start()
    {
        Button retry = retryButton.GetComponent<Button>();
        Button returnToMainMenu = returnToMainMenuButton.GetComponent<Button>();
        Button quit = quitButton.GetComponent<Button>();

        retry.onClick.AddListener(RetryLevel);
        returnToMainMenu.onClick.AddListener(ReturnToMainMenu);
        quit.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        CheckIfPlayerDied();

        if (isPlayerDead)
        {
            SetDeathScreenActivity();
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            //do nothing?
        }
    }

    void CheckIfPlayerDied()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            isPlayerDead = true;
        }
        else
        {
            isPlayerDead = false;
        }
    }

    void SetDeathScreenActivity()
    {
        if (isPlayerDead == true)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            deathScreen.SetActive(false);
        }
    }

    void RetryLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
