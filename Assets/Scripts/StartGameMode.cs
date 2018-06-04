using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameMode : MonoBehaviour
{

    public void ChooseGameMode(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
