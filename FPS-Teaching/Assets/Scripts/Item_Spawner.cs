using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : MonoBehaviour
{
    public GameObject[] itemToSpawn;
    public GameObject[] spawnPoints;

    public List<GameObject> SpawnPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");

        for(int i = 0; i < spawnPoints.Length; i++){
            SpawnPoints.Add(spawnPoints[i]);
        }
        for(int i = 0; i < SpawnPoints.Count; i++){
            SpawnPoints.RemoveAt(Random.Range(0, SpawnPoints.Count - 1));
        }

        Spawn();
    }

    void Spawn(){
        for(int i = 0; i < SpawnPoints.Count; i++){
            Instantiate(itemToSpawn[Random.Range(0, itemToSpawn.Length)], SpawnPoints[i].transform);
        }
    }
}
