using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoAlPlayerTwoController : MonoBehaviour
{
    /*Aqui lo que se intenta hacer es acceder */
    HealthPlayerTwoController VidaAlPlayerTwo;

    public int cantidadDeLaVida;
    public float DañoGeneradoPorElTiempoDelAgente;
    float DañoActualPorElAgente;

	void Start()
    {
        //Aqui lo que se hace es que buscar el tag llamado: "PlayerTwo"
        VidaAlPlayerTwo = GameObject.FindWithTag("PlayerTwo").GetComponent<HealthPlayerTwoController>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerTwo")
        {
            DañoActualPorElAgente += Time.deltaTime;
            if (DañoActualPorElAgente > DañoGeneradoPorElTiempoDelAgente)
            {
                VidaAlPlayerTwo.maxHealth += cantidadDeLaVida;
                DañoActualPorElAgente = 0.0F;
            }

            if (VidaAlPlayerTwo.maxHealth == 0)
            {
				GameOver();
			}
        }
    }

	/*Método en el cual se llama la escena: Game over.*/
	public void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}









}
