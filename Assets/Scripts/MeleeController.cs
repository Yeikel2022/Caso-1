using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : AttackController
{
	[SerializeField]
	Transform attackPoint;/* Esto sirve para indicar el punto de ataque, eso se -
	                       * vio por el sphere collider.*/
	
	[SerializeField]
	float damage;/*Esto sirve para indicar el punto de da�o que va a recibir el objeto.*/

	Animator _animator; /*Esto sirve para indicar las estad�sticas de ataque, -
	                     * adem�s de ser un atributo para el Awake.*/
	Transform target;

/*=========================================================================================================================================================================*/


	/*Aqu� es cuando se inicia todo y se ejecuta primero:*/
	private void Awake()
	{
		/* Aqui lo que se hace es buscar el archivo.Animator que -
		 * tiene el objeto, que en este caso es Sword.*/
		_animator = GetComponent<Animator>();
	}



	/*Con este m�todo nos indica cuando hay que atacar, adem�s -
	 * de enlazar con el m�todo abstracto: AttackController:*/
	public override void Attack()
	{
		/*Aqu� lo que se esta haciendo es pasar el nombre del parametro -
		 que hab�amos creado en el animator, que es de tipo trigger, el -
		 cual se llama: attack.*/
		_animator.SetTrigger("attack");
	}



	/*Con este m�todo nos permitir� colocar un evento en la secci�n: Animation, -
	 del objeto: Sword, esto porque cada 30s es lo que vamos a realizar el ataque -
	 por eso es que se coloca un evento para indicarle (por medio de este c�digo) -
	 cuando hacer el ataque:*/
	public void OnAttack()
	{
		/*Nos permite saber si colisiona con 1 o m�s objetos del videojuego, -
		 * adem�s de que lo almacena dentro de una lista de collider llamada: -
		 * others.*/
		Collider[] others = Physics.OverlapSphere(attackPoint.position, 0.3F);
		
		/*Si detecta que colisiono con m�s objetos: */
		foreach (Collider other in others)
		{
			/*Si devolver�a un controlador de tipo salud (1.1): */
			HealthController controller = other.GetComponent<HealthController>();
			
			/*Si ese controller es nulo, entonces siga adelante:*/
			if(controller == null)
			{
				continue;
			}

			/*Enviara el valor de da�o que uno causa a la persona (objeto):*/
			controller.TakeDamage(damage);
		}
	}
}
