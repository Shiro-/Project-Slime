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

    void Update()
    {
        if(gameObject.GetComponent<Spawner>().currentState == Spawner.SpawningState.Wave)
        {
            //I add +1 because we start at wave 1 not 0
            waveText.text = "Current Wave: " + (gameObject.GetComponent<Spawner>().currentWave + 1);
        }
        else if(gameObject.GetComponent<Spawner>().currentState == Spawner.SpawningState.Infinite)
        {
            distText.text = "Distance: " + p.dist;
        }
        else
        {
            Debug.Log("Something went wrong somewhere");
        }
 
    }
  
}
