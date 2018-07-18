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
    int startValue;

    void Awake()
    {
        GameObject startControllerObject = GameObject.FindWithTag("StartController");
        StartGameMode gameValue = startControllerObject.GetComponent<StartGameMode>();
        startValue = gameValue.mode;
    }

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
        if (startValue == 1)
        {
            SetDeathScreenActivity();
            Time.timeScale = 1f;
            SceneManager.LoadScene("WaveDifficulty");
        }
        else if (startValue == 2)
        {
            SetDeathScreenActivity();
            Time.timeScale = 1f;
            SceneManager.LoadScene("InfiniteDifficulty");
        }
        else
        {
            Debug.Log("Somehow you reached here and you shouldn't be here.");
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
