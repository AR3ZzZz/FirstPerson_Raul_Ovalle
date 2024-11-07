using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] ParticleSystem system;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cam.transform.position,cam.transform.forward,out RaycastHit hitInfo, misDatos.distanciaAtaque)) 
            {
                hitInfo.transform.GetComponent<Pedroski>().RecibirDanho(misDatos.danhoAtaque);
            }
        }
    }
}
