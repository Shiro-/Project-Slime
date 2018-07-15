using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player p;
    public Text distText;
    public Text waveText;

    int startValue;

    private void Awake()
    {
        //This gets what version of the game is being played
        GameObject startControllerObject = GameObject.FindWithTag("StartController");
        StartGameMode gameValue = startControllerObject.GetComponent<StartGameMode>();
        startValue = gameValue.mode;
    }

    private void Start()
    {
     
    }

    private void Update()
    {
        if(startValue == 1)
        {
            waveText.text = "Current Wave: " + gameObject.GetComponent<Spawner>().currentWave;
        }
        else if(startValue == 2)
        {
            distText.text = "Distance: " + p.dist.ToString();
        }
        
    }
}
