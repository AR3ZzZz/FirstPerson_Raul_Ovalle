using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyPart : MonoBehaviour
{
    //Este script iria asignado a las partes con collider del Ragdoll

    [SerializeField] Pedroski mainScript;

    void Start()
    {
        
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
}
