using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawnPositions;
    public Transform slimes;

    public int enemyCount;

    public float waitTime;
    public float spawnTime;

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

        for(int i = 0; i < enemyCount; i++)
        {
            Debug.Log(i);
            Instantiate(slimes, RandomSpawnPosition(spawnPositions), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
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
        return newPositions[Random.Range(0, (pos.Length - 1))];
    }
}
