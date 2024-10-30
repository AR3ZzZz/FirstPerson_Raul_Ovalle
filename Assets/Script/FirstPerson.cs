using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
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
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;   //Centra en la raton y lo oculta
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
        float angulo =Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;



        if (input.magnitude > 0)
        {
             Vector3 movimiento = Quaternion.Euler (0, angulo, 0) * Vector3.forward;
    
             transform.eulerAngles = new Vector3(0, angulo, 0);
            
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
