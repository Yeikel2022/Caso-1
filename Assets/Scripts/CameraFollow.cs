using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	/* C�mara para que lo siga al player:
*/
	//Lo que vamos a perseguir:
	[SerializeField]
	Transform target;

	//Distancia entre la c�mara y el objeto que voy a seguir:
	[SerializeField]
	Vector3 offset;

	//Lo mismo que el FixedUpdate, -
	//pero despu�s de que todo se haya renderizado:
	private void LateUpdate()
	{
		transform.position = target.position + offset;
	}
}
