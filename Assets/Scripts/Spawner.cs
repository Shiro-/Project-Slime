using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    enum SpawningState { Wave, Infinite };
    //This will most likely be set through a menu
    SpawningState currentState = SpawningState.Infinite;

    public GameObject[] spawnPositions;
    public Transform slimes;

    public float waitTime;
    public float spawnTime;

    bool isPlayerDead;

    [System.Serializable]
    public class Wave
    {
        public int slimeCount;
        //Testing purposes
        public Transform[] slimeTypes;
        public float timeBetweenWaves;
    }

    public Wave[] waves;
    public int waveCount;

    //
    private Vector3 previousPoint;
    //

    private void Start()
    {
        //Time before we start spawning
        StartCoroutine(SpawnSlimes());
    }

    private void Update()
    {
        //Check which spawn we are on
    }


    IEnumerator SpawnSlimes()
    {
        //Spawning logic
        yield return new WaitForSeconds(waitTime);

        if(currentState == SpawningState.Infinite)
        {
            while (true)
            {
                Instantiate(slimes, RandomSpawnPosition(spawnPositions), Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);

                CheckIfPlayerHasDied();

                if (isPlayerDead == true)
                {
                    break;
                }
            }
        }
        else if(currentState == SpawningState.Wave)
        {
            //do something
            while(waveCount > 0)
            {

            }
        }
        else
        {
            Debug.Log("Spawning state does not exist");
        }
        
        yield return new WaitForSeconds(spawnTime);
    }

    Vector3 RandomSpawnPosition(GameObject[] pos)
    {
        Vector3[] newPositions = new Vector3[pos.Length];
        //Vector3[] finalPosition = new Vector3[2];

        for (int i = 0; i < pos.Length; i++)
        {
            newPositions[i] = new Vector3(pos[i].transform.position.x, pos[i].transform.position.y, Random.Range(-pos[i].transform.position.z, pos[i].transform.position.z));
        }

        //Choose between the random position or the base position
        return newPositions[Random.Range(0, pos.Length)];
    }

    void CheckIfPlayerHasDied()
    {
        if(GameObject.FindWithTag("Player") == null)
        {
            isPlayerDead = true;   
        }
    }
}
