using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Arma")]
public class ArmaSO : ScriptableObject
{
     public int balasCargador;
     public int balasBolsa;
     public float cadenciaAtaque;
     public float distanciaAtaque;
     public float danhoAtaque;
     public bool cambiarModoDisparo;
     public bool disparoAutomatico;
     public bool disparoSemi;

}
