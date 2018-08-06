using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player p;
    public Text distText;
    public Text waveText;

    int startValue;

    bool isPlayerDead;

    SpawningState currentState;

    void Awake()
    {
        ////This gets what version of the game is being played
        //GameObject startControllerObject = GameObject.FindWithTag("StartController");
        //StartGameMode gameValue = startControllerObject.GetComponent<StartGameMode>();
        //startValue = gameValue.mode;

        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(currentState == SpawningState.Wave)
        {
            //I add +1 because we start at wave 1 not 0
            waveText.text = "Current Wave: " + (gameObject.GetComponent<Spawner>().currentWave + 1);
        }
        else if(currentState == SpawningState.Infinite)
        {
            distText.text = "Distance: " + p.dist;
        }
        else
        {
            Debug.Log("Something went wrong somewhere");
        }
 
    }
  
}
