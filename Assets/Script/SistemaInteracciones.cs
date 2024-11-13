using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] float distancia;

    Camera cam;
    Transform interactuableActual;
    void Start()
    {
        cam = Camera.main;

    }

    void Update()
    {
        DeteccionInteractuable();
    }

    private void FixedUpdate()
    {
        
    }

    private void DeteccionInteractuable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, distancia))
        {
            if (hitInfo.collider.TryGetComponent(out AmmoBox caja))
            {
                interactuableActual = caja.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    caja.AbrirCaja();
                }

            }
        }
        else if (interactuableActual != null)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }
    }
}
