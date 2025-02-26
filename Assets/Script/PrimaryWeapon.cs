using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon : MonoBehaviour
{
    [Header("Weapon Info")]
    [SerializeField] private ArmaSO misDatos;
    int balasMaximasCargador;
    float proximoDisparo;
    bool recargando;



    Camera cam;

    void Start()
    {
        cam = Camera.main;
        balasMaximasCargador = misDatos.balasCargador;
    }

    // Update is called once per frame
    void Update()
    {
        CambiarDisparo();
        if (!recargando)
        {
            if (misDatos.disparoAutomatico)
            {
                if (Input.GetMouseButton(0) && Time.time >= proximoDisparo)
                {
                    proximoDisparo = Time.time + 1f / misDatos.cadenciaAtaque;
                    Disparar();
                }
            }
            else if (misDatos.disparoSemi)
            {
                if (Input.GetMouseButtonDown(0) && Time.time >= proximoDisparo)
                {
                    proximoDisparo = Time.time + 1f / misDatos.cadenciaAtaque;
                    Disparar();
                }
            }
        }
        

    }

    private void Disparar()
    {
        
        if(misDatos.balasCargador > 0)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                TryGetComponent(out Pedroski enemy);
                {

                }
            }
            misDatos.balasCargador --;
        }
           
       
    }

    void Recarga()
    {
        if (!recargando && misDatos.balasCargador < balasMaximasCargador)
        {
            recargando = true;
        }
    }

    void FinRecarga()
    {
        int balasRecargadas = balasMaximasCargador - misDatos.balasCargador;
        misDatos.balasCargador = balasMaximasCargador;
        misDatos.balasBolsa -= balasRecargadas;
        recargando = true;

    }

    void CambiarDisparo()
    {
        if (misDatos.cambiarModoDisparo)
        {
            if (Input.GetMouseButtonDown(3) && misDatos.disparoAutomatico)
            {
                misDatos.disparoAutomatico = false;
                misDatos.disparoSemi = true;
            }
            else if (Input.GetMouseButtonDown(3) && misDatos.disparoSemi)
            {
                misDatos.disparoAutomatico = true;
                misDatos.disparoSemi = false;
            }
        }
        
    }
}
