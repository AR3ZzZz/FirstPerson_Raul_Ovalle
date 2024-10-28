using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{

    [SerializeField] float velocidadMovimiento;
    [SerializeField] float smoothTime;
    Animator anim;
    //[SerializeField]
    //[SerializeField]

    float velocidadRotacion;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MoverYRotar();
    }
    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, smoothTime);


        Debug.Log(velocidadRotacion);
        if (input.magnitude > 0)
        {
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            //Me muevo hacia donde miro
            characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }
}
