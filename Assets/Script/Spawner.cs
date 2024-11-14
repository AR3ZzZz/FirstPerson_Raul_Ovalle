using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] Spawns;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            Instantiate(enemyPrefab, Spawns[Random.Range(0, Spawns.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
       
    }
}
