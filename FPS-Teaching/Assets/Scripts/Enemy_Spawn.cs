using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.1f, spawnRate);
    }

    void Spawn(){
        Instantiate(enemyToSpawn[Random.Range(0, enemyToSpawn.Length)], transform.position, Quaternion.identity);
    }
}
