using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] Spawns;
    [SerializeField] int spawnsPerLevel;
    [SerializeField] int roundsPerLevel;
    [SerializeField] int levelNumber;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] float timeBetweenRound;
    [SerializeField] float timeBetweenLevels;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        for (int actualLevel = 0; actualLevel < levelNumber; actualLevel++)
        {
            for (int actualRound = 0; actualRound < roundsPerLevel; actualRound++)
            {
                for (int spawnNumber = 0; spawnNumber < spawnsPerLevel; spawnNumber++)
                {
                    Instantiate(enemyPrefab, Spawns[Random.Range(0, Spawns.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(timeBetweenSpawn);
                    
                }

                //text new level
                yield return new WaitForSeconds(timeBetweenRound);
            }

            //text new level
            yield return new WaitForSeconds(timeBetweenLevels);
        }        
       
    }
}
