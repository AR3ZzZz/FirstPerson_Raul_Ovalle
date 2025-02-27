using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject pedro;
    [SerializeField] private Transform[] puntosSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawnear()
    {
        while (true)
        {
            Instantiate(pedro, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
    
}


