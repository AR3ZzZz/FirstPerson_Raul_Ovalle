using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyPart : MonoBehaviour
{
    //Este script iria asignado a las partes con collider del Ragdoll

    [SerializeField] Pedroski mainScript;
    [SerializeField] float dmgMultiplicator;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    public void RecibirDanho(float x)
    {
        //mainScript.VidaEnemigo -= RecibirDanho;
        if (mainScript.VidaEnemigo <= 0)
        {
            mainScript.Morir();
        }

    }
    public void Explotar(float x, Vector3 puntoImpacto, float y, float up)
    {

        rb.AddExplosionForce(x, puntoImpacto, y, up, ForceMode.Impulse);
    }
}
