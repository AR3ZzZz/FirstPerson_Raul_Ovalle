using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AbrirCaja()
    {
        animator.SetTrigger("AbrirCaja");
    }
   
}
