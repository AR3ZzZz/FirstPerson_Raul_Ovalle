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
}
