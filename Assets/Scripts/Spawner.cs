using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    enum SpawningState { Wave, Infinite };
    //This will most likely be set through a menu
    SpawningState currentState = SpawningState.Wave;

    public GameObject[] spawnPositions;
    public Transform slimes;

    //Infinite State
    public float waitTimeBeforeSpawning;
    public float spawnTime;

    //Wave State
    public float waitTimeBetweenWaves;

    bool isPlayerDead;

    [System.Serializable]
    public class Wave
    {
        public int slimeCount;
        //Testing purposes
        public Transform[] slimeTypes;
    }

    public Wave[] waves;
    public int waveCount;
    public int currentWave;

    //
    private Vector3 previousPoint;
    //

    private void Start()
    {
        currentWave = 0;
        waveCount = waves.Length;

        //Time before we start spawning
        if (currentState == SpawningState.Infinite)
        {
            StartCoroutine(SpawnInfiniteSlimes());
        }
        else if (currentState == SpawningState.Wave)
        {
            StartCoroutine(SpawnWaveSlimes());
        }
        else
        {
            //If somehow we end up here, display a message in console
            Debug.Log("Current state is invalid");
        }
    }

    private void Update()
    {
        //Check which spawn we are on
    }

    IEnumerator SpawnInfiniteSlimes()
    {
        //Spawning logic
        yield return new WaitForSeconds(waitTimeBeforeSpawning);

        while (true)
        {
            Instantiate(slimes, RandomSpawnPosition(spawnPositions), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);

            //If our player died, get out of this loop
            CheckIfPlayerHasDied();
            if (isPlayerDead == true)
            {
                break;
            }
        }

        yield return new WaitForSeconds(spawnTime);
    }

    IEnumerator SpawnWaveSlimes()
    {
        Transform[] enemyTypes = waves[currentWave].slimeTypes;
        int numberOfTypes = enemyTypes.Length;

        while (true)
        {
            if (currentWave < waveCount)
            {
                yield return new WaitForSeconds(waitTimeBetweenWaves);
                for (int i = 0; i < waves[currentWave].slimeCount; i++)
                {
                    Instantiate(enemyTypes[Random.Range(0, numberOfTypes)], RandomSpawnPosition(spawnPositions), Quaternion.identity);
                    yield return new WaitForSeconds(spawnTime);
                }
                currentWave++;

                //If our player died, get out of this loop
                CheckIfPlayerHasDied();
                if (isPlayerDead == true)
                {
                    break;
                }
            }
            else
            {
                break;
            }

        }

        yield break;
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
        if (GameObject.FindWithTag("Player") == null)
        {
            isPlayerDead = true;
        }
    }
}
