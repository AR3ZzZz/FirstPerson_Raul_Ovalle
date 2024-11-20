using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Transform spawnGrenade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clon = Instantiate(grenadePrefab,spawnGrenade.position,spawnGrenade.rotation);
        }
    }
}
