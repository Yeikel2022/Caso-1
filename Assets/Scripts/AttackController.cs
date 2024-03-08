using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    /*Método que sirve como una clase abstracta.
     Esto porque se va a necesitar para poder -
     realizar instancias de una mejor manera.*/
    public abstract void Attack();



}
