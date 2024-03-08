using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * Implementar sistema de salud al jugador vale 30 puntos (ya se tiene el health controller, eso es un sistema de salud)
// * Agentes dañan 5 (sistema de ataque a implementar)
// * Los objetos oscilantes dañan 15 (sistema de ataque a implementar)


// * Pierden la vida, reinician la escena 20 Puntos
public class HealthController : MonoBehaviour
{

    [SerializeField]
    float maxHealth = 100.0F;/*Vida máxima del objeto.*/

    float _currentHealth;/*Vida (o salud) actual del objeto.*/

/*=========================================================================================================================================================================*/


	/*Aquí es cuando se inicia todo y se ejecuta primero:*/
	private void Awake()
	{
		/*Con este código lo que hacemos es indicar que la -
		 vida actual sea la vida máxima, ya que asi se manejan -
		 en los videojuegos.*/
		_currentHealth = maxHealth;
	}



	/*Con este método lo que hace es con el daño recibido, -
	  quitarle vida al objeto hasta desaparecerlo.*/
	public void TakeDamage(float damage)
	{
		/* Aquí lo que se está haciendo es restarle lo que genero el daño -
		 * para agregarlo a la vida actual, para asi saber bien como va bajando -
		 * la vida del objeto.
		 *
		 * Nota: El absoluto siempre será positivo.*/
		_currentHealth -= Mathf.Abs(damage);

		/*Si la vida actual es menor o igual a cero -
		 * (ósea que perdiste toda la vida), entonces desaparezca.*/
		if (_currentHealth <= 0.0F)
		{
			Destroy(gameObject);
		}
	}



	/* Con este método lo que hace es recuperar la vida -
	 * del objeto.*/
	public void Heal(float repair)
	{
		/*Aquí hace que pueda recuperar la vida y lo almacene en -
		  la vida actual.*/
		_currentHealth += Mathf.Abs(repair);
	}





}
