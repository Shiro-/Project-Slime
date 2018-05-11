using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnConstraints;
    public Transform slimes;

    public float spawnRate;

    private void Start()
    {
        //Time before we start spawning
    }

    private void Update()
    {
        //Check which spawn we are on
        //Start coroutines
    }


    IEnumerator SpawnSlimes()
    {
        //Spawning logic
        yield break;
    }
}
