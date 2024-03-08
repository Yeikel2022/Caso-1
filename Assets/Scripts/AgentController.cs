using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Ataque del Agente vale 25 puntos
public class AgentController : MonoBehaviour
{
    [SerializeField]
    Transform target;

	// Distancia minima
	[SerializeField]
	float distanciaMinima;

	NavMeshAgent _navAgent;

	private void Awake()
	{
		_navAgent = GetComponent<NavMeshAgent>();
	}


	/*CASO 1 - AQUI EN EL UPDATE, vamos a necesitar una distancia mínima.*/
	private void Update()
	{
		float distance = Vector3.Distance(transform.position, target.position);
		// Si la distancia es menor o igual a la distancia mínima entonces ataque
		if (distance <= distanciaMinima)
		{
			_navAgent.SetDestination(target.position);
		}
	}




}

//Agregar otro controller (otro objeto, otra arma) para atacar, de tipo melee