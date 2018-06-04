using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class StartGameMode : MonoBehaviour
{
    public Button waveModeButton;
    public Button infiniteModeButton;

    void Start()
    {
        Button wave = waveModeButton.GetComponent<Button>();
        Button infinite = infiniteModeButton.GetComponent<Button>();

        wave.onClick.AddListener(StartWaveMode);
        infinite.onClick.AddListener(StartInfiniteMode);
    }

    public void StartWaveMode()
    {
        Debug.Log("You chose wave mode");
    }

    public void StartInfiniteMode()
    {
        Debug.Log("You chose infinite mode");
    }
    //public void ChooseGameMode(string scene)
    //{
    //    SceneManager.LoadScene(scene);
    //}
}
