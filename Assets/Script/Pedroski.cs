using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedroski : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] Transform puntoImpacto;
    [SerializeField] float radioImpacto;
    [SerializeField] LayerMask danhable;
    [SerializeField] int danhoEnemigo;

    float vidaEnemigo;


    bool puedoDanhar;
    NavMeshAgent agent;
    FirstPerson player;
    Animator animator;
    bool ventanaAbierta;

    [SerializeField] Rigidbody[] huesos;
    [SerializeField] Collider[] colliders;

    public float VidaEnemigo { get => vidaEnemigo; set => vidaEnemigo = value; }

    void Start()
    {
        vidaEnemigo = 100;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        animator = GetComponent<Animator>();
        CambiarEstadoHuesos(true);

        int animCorrer = Random.Range(0, 2);

        if (animCorrer == 0)
        {
            animator.SetBool("Running1", true);
        }
        else
        {
            animator.SetBool("Running2", true);

        }
    }

    void Update()
    {
        if (vidaEnemigo > 0)
        {
            SeguiryAtacar();
        }
        if (ventanaAbierta && puedoDanhar)
        {

            DetectarImpacto();
        }
    }

    private void DetectarImpacto()
    { 
         Collider [] collDetectados = Physics.OverlapSphere(puntoImpacto.position, radioImpacto, danhable);
        

        if (collDetectados.Length > 0) 
        {
            for (int i = 0;  i < collDetectados.Length;  i++)
            {
                if (collDetectados[i].TryGetComponent(out FirstPerson player))
                {
                    player.RecibirDanho(danhoEnemigo);
                }
                
            }
            puedoDanhar = false;
        }
    }

    private void SeguiryAtacar()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            agent.isStopped = true;
            animator.SetBool("Attacking", true);
        }
    }

    void FinAnimacion()
    {
        agent.isStopped = false;
        animator.SetBool("Attacking", false);
    }

    void InicioVentana() 
    {
        ventanaAbierta = true;
    }

    void FinVentana()
    {
        ventanaAbierta = false;
        puedoDanhar = true;
    }
    //2checkboxes, gameobjects

    public void Morir()
    {

        agent.enabled = false;
        animator.enabled = false;
        CambiarEstadoHuesos(false);
    }
    void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
    
}
