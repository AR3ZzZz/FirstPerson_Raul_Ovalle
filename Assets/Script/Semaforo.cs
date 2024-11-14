using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SemaforoEjemplo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SemaforoEjemplo()
    {
        Debug.Log("Green");
        yield return new WaitForSeconds(2);

        Debug.Log("Yellow");
        yield return new WaitForSeconds(2);

        Debug.Log("Red");
        
    }
}
