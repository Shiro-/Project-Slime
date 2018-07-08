using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player p;
    public Text distText;

    private void Start()
    {
     
    }

    private void Update()
    {
        distText.text = "Distance: " + p.dist;
    }
}
