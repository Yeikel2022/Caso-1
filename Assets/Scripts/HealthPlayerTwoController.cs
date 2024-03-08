using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


// * Implementar sistema de salud al jugador vale 30 puntos
// (ya se tiene el health controller, eso es un sistema de salud)
// * Agentes dañan 5 (sistema de ataque a implementar)
// * Los objetos oscilantes dañan 15 (sistema de ataque a implementar)


// * Pierden la vida, reinician la escena 20 Puntos
public class HealthPlayerTwoController : MonoBehaviour
{
	[SerializeField]
    public float maxHealth = 100.0F;/*Vida máxima del objeto.*/

	public Image Barra_De_Vida;

/*=========================================================================================================================================================================*/

	private void Update()
	{
		//Con el Mathf.Clamp, lo que hacemos que se le define un -
		//float, un minimo de vida y un máximo de vida.
		maxHealth = Mathf.Clamp(maxHealth, 0, 100.0F);

		//Esto hace que pueda llenarse o no la vida.
		Barra_De_Vida.fillAmount = maxHealth / 100;
	}

}
