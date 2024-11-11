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

    Rigidbody[] huesos;

    public float VidaEnemigo { get => vidaEnemigo; set => vidaEnemigo = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        animator = GetComponent<Animator>();

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
        SeguiryAtacar();
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
                collDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoEnemigo);
            }
            puedoDanhar = false;
        }
    }

    private void SeguiryAtacar()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
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
    }
    void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
}
