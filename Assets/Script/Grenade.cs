using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{    
    [SerializeField] float speed;
    [SerializeField] float explotionRadius;
    [SerializeField] float explotionForce;
    [SerializeField] GameObject Explotion;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject,1.5f);
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Instantiate(Explotion, transform.position, Quaternion.identity);
    }
}
