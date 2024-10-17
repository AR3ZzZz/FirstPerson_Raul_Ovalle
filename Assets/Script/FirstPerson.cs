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
        characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }
}
