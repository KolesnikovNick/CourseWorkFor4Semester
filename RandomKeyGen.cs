using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomKeyGen : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject gameObjectToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        
        Spawn();
    }

    GameObject SelectRandomSpawner()
    {
        GameObject randomSpawner;
        randomSpawner = spawnPoints[Random.Range(0, spawnPoints.Length)];
        return randomSpawner;
    }
    // Update is called once per frame
    void Spawn()
    {
        for (int i = 0; i < KeyExit.keyPiscesToWin-1; i++)
        {
            GameObject selectedSpawner;
            selectedSpawner = SelectRandomSpawner();
            Instantiate(gameObjectToSpawn, selectedSpawner.transform.position,
                selectedSpawner.transform.rotation);
            var spawnPointsList = spawnPoints.ToList();
            spawnPointsList.Remove(selectedSpawner);
            spawnPoints = spawnPointsList.ToArray();
        }
    }
}
