using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] int vidaMaxima;
    int vidaActual;

    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text vidasText;


    [Header("Mov")]
    [SerializeField] float velocidadMovimiento;
    [SerializeField] float factorGravedad;
    [SerializeField] float alturaSalto;

    [Header("DeteccionSuelo")]
    [SerializeField] float radioDeteccion;
    [SerializeField] Transform pies;
    [SerializeField] LayerMask queEsSuelo;
    CharacterController characterController;
    Vector3 movVertical;
    //Sirve para los saltos y para la gravedad

    [Header("Pisadas")]
    [SerializeField] AudioSource sourcePisadas;
    [SerializeField] AudioClip[] sonidosPisadas;
    [SerializeField] float tiempoEntrePisadas;
    float proximaPisada;
    bool pieDer;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;   //Centra en la raton y lo oculta
        vidaActual = vidaMaxima;
        vidasText.SetText("HP: " + vidaActual);

    }

    void Update()
    {
        MoverYRotar();
        AplicarGravedad();

        if (EnSuelo())
        {
            movVertical.y = 0;
            Salto();
        }

        if (EnSuelo() && characterController.velocity.magnitude > 0 && Time.time >= proximaPisada)
        {
            PisadasPlayer();
            proximaPisada = Time.time + tiempoEntrePisadas;
        }

    }

    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movVertical.y += Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
        }
    }

    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3 (h, v, 0).normalized;
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);




        if (input.magnitude > 0)
        {
    
            float angulo =Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Vector3 movimiento = Quaternion.Euler (0, angulo, 0) * Vector3.forward;
            
             //Me muevo hacia donde miro
            characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

        
    }

    void AplicarGravedad()
    {
        movVertical.y += factorGravedad * Time.deltaTime;
        //Gravedad M/S2
        characterController.Move(movVertical * Time.deltaTime);
    }

    bool EnSuelo()
    {
        //esfera de deteccion
        bool result = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return result;
    }
    public void RecibirDanho(int danho)
    {
        vidaActual -= danho;
        vidasText.SetText("HP: " + vidaActual);
        if (vidaActual <= 0) 
        {
            vidaActual = 0;
            Morir();
        }
    }

    private void Morir()
    {
        gameManager.Lose();
    }

    void PisadasPlayer()
    {        
        if (pieDer)
        {
            sourcePisadas.PlayOneShot(sonidosPisadas[0]);
        }
        else 
        {
            sourcePisadas.PlayOneShot(sonidosPisadas[1]);
        }
        pieDer = !pieDer;
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
