using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] float velocidadMovimiento;
    //[SerializeField] 
    //[SerializeField]
    //[SerializeField]
    //[SerializeField]
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoverYRotar();
    }
    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = new Vector3 (h, 0, v).normalized;

        float anguloRotacion =Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        if (movimiento.magnitude > 0)
        {
         //Orientacion hacia el movimiento
          transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

         //Me muevo hacia donde miro
         characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }
    }
}
