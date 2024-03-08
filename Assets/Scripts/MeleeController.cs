using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : AttackController
{
	[SerializeField]
	Transform attackPoint;/* Esto sirve para indicar el punto de ataque, eso se -
	                       * vio por el sphere collider.*/
	
	[SerializeField]
	float damage;/*Esto sirve para indicar el punto de daño que va a recibir el objeto.*/

	Animator _animator; /*Esto sirve para indicar las estadísticas de ataque, -
	                     * además de ser un atributo para el Awake.*/
	Transform target;

/*=========================================================================================================================================================================*/


	/*Aquí es cuando se inicia todo y se ejecuta primero:*/
	private void Awake()
	{
		/* Aqui lo que se hace es buscar el archivo.Animator que -
		 * tiene el objeto, que en este caso es Sword.*/
		_animator = GetComponent<Animator>();
	}



	/*Con este método nos indica cuando hay que atacar, además -
	 * de enlazar con el método abstracto: AttackController:*/
	public override void Attack()
	{
		/*Aquí lo que se esta haciendo es pasar el nombre del parametro -
		 que habíamos creado en el animator, que es de tipo trigger, el -
		 cual se llama: attack.*/
		_animator.SetTrigger("attack");
	}



	/*Con este método nos permitirá colocar un evento en la sección: Animation, -
	 del objeto: Sword, esto porque cada 30s es lo que vamos a realizar el ataque -
	 por eso es que se coloca un evento para indicarle (por medio de este código) -
	 cuando hacer el ataque:*/
	public void OnAttack()
	{
		/*Nos permite saber si colisiona con 1 o más objetos del videojuego, -
		 * además de que lo almacena dentro de una lista de collider llamada: -
		 * others.*/
		Collider[] others = Physics.OverlapSphere(attackPoint.position, 0.3F);
		
		/*Si detecta que colisiono con más objetos: */
		foreach (Collider other in others)
		{
			/*Si devolvería un controlador de tipo salud (1.1): */
			HealthController controller = other.GetComponent<HealthController>();
			
			/*Si ese controller es nulo, entonces siga adelante:*/
			if(controller == null)
			{
				continue;
			}

			/*Enviara el valor de daño que uno causa a la persona (objeto):*/
			controller.TakeDamage(damage);
		}
	}
}
