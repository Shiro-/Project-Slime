using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class StartGameMode : MonoBehaviour
{
    public Button waveModeButton;
    public Button infiniteModeButton;

    public int mode;

    void Start()
    {
        Button wave = waveModeButton.GetComponent<Button>();
        Button infinite = infiniteModeButton.GetComponent<Button>();

        wave.onClick.AddListener(StartWaveMode);
        infinite.onClick.AddListener(StartInfiniteMode);
    }

    void StartWaveMode()
    {
        Debug.Log("You chose wave mode");
        mode = 1;
        DontDestroyOnLoad(this.gameObject);
        //In the future, we will have different scenes for the different game modes
        SceneManager.LoadScene("ProofOfConcept");
    }

    void StartInfiniteMode()
    {
        Debug.Log("You chose infinite mode");
        mode = 2;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("ProofOfConcept");
    }
    //public void ChooseGameMode(string scene)
    //{
    //    SceneManager.LoadScene(scene);
    //}
}
