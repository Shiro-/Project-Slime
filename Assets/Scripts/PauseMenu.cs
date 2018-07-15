using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused = false;

    void Update()
    {
        
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

}
