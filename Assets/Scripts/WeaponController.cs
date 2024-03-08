using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Segunda Arma (en el player) 25 PUNTOS }Todo 
// * Animaci�n por rotaci�n				 }listo


public class WeaponController : MonoBehaviour
{
	[SerializeField]
	AttackController[] weapon;/*Esto es un arreglo para guardar los datos del AttackController, -
	                           * las armas y ataques que se realizan.*/

	AttackController _currentWeapon; /*Para capturar el momento en que se hace un ataque.*/

	int _selectedWeapon; /*Es una variable global para poder tener el dato del arma seleccionada.*/

/*=========================================================================================================================================================================*/

	/*Este m�todo es para que cuando comienza -
	 el juego, ya tenga esto realizado.*/
	private void Start()
	{
		/*Esto es para que inicie en 0 y se pueda seleccionar el arma -
		 correctamente.*/
		_selectedWeapon = 0;
		SelectWeapon();

		/* Aqui lo que se esta haciendo es que se le esta -
		 * pasando la 1ra arma que tenga.*/
		_currentWeapon = weapon[0];
	}



	/* Aqui cuando se va actualizar, entonces -
	 * realize los siguientes m�todos.*/
	private void Update()
	{
		HandleScrollWheel();
		HandleAttack();
	}



	/*Este es un m�todo que nos ayuda a seleccionar las armas disponibles que -
	 tenemos, pero que solo active la que uno desea usar.*/
	private void SelectWeapon()
	{
		/*Aqu� es un recorrido, viendo si el index es menor a la longitud -
		  de todo el arreglo "weapon", entonces que valla aumentando.*/
		for (int index = 0; index < weapon.Length; index++)
		{
			/*Sirve para poder almacenar el dato que esta en el -
			  arreglo.*/
			AttackController controller = weapon[index];

			/*Sirve para pode indicar que si el index -
			 es igual a la arma seleccionada en la variable -
			  _selectWeapon, entonces que active dicha arma.*/
			bool isActive = (_selectedWeapon == index);

			/*Con esta parte lo que indicamos es que active -
			 dicha arma.*/
			controller.gameObject.SetActive(isActive);

		}
		/*Aqu� ya selecciona el arma que esta ingresando en el -
		 m�todo.*/
		_currentWeapon = weapon[_selectedWeapon];
	}



	/* Este es un m�todo que nos ayuda a detectar como se manejando el scroll -
	 * del rat�n de la persona, para asi poder realizar de mejor manera -
	 * el proceso de selecci�n del arma.
	 */
	private void HandleScrollWheel()
	{
		/*Esto es para poder detectar el movimiento del scroll del rat�n.*/
		float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
		
		/*Aqu� lo que se hace es que si no es 0, entonces -
		 empiece a incrementar o disminuir la selecci�n de las armas, -
		 esto para hacer el efecto de selecci�n.*/
		if (scrollWheel != 0.0F)
		{
			/*Aqu� lo que se hace es que, si el scrollWheel -
			 (que seria la ruedita del rat�n) que esta siendo -
			 almacenada en _selectWeapon es mayor a cero, entonces -
			 quiere decir que se esta dirigiendo hacia arriba, por lo -
			 que lo aumenta en 1, pero en dado caso que va hacia abajo, -
			 entonces lo disminuye en 1.*/
			_selectedWeapon = scrollWheel > 0.0F
				? _selectedWeapon + 1
				: _selectedWeapon - 1;

			/*Aqu� lo que se refiere es que si el arma seleccionada -
			  es mayor o igual a la longitud de todo el inventario -
			  de las armas (quiere decir que llego al limite) entonces -
			  que lo coloque nuevamente en cero, para asi volver a selec-
			  cionar, pero si no es mayor, entonces valla rest�ndole uno -
			  a la longitud del inventario de las armas.*/
			if (_selectedWeapon >= weapon.Length)
			{
				_selectedWeapon = 0;
			}
			else if (_selectedWeapon < 0)
			{
				_selectedWeapon = weapon.Length - 1;
			}

			/*Aqu� se llama el m�todo: SelectWeapon, para -
			  poder hacer el proceso de selecci�n del arma.*/
			SelectWeapon();
		}
	}



	/*Este es un m�todo que nos ayuda a saber cuando ataco la persona.*/
	private void HandleAttack()
	{
		/*Aqu� lo que se refiere es que si presionaron el bot�n -
		  para poder atacar, entonces que almacene ese dato en: -
		  _currentWeapon y que llame el m�todo abstracto: -
		  Attack, para ahora poder atacar.
		  Adem�s que es el mismo para todos.*/
		if (Input.GetButton("Fire1"))
		{
			_currentWeapon.Attack();
		}
	}










}
