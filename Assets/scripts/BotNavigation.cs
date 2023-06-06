using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotNavigation : MonoBehaviour
{
    public Transform[] waypoints; // Array de puntos de navegación
    private int currentWaypoint = 0; // Índice del punto de navegación actual
    private UnityEngine.AI.NavMeshAgent agent; // Componente NavMeshAgent para la navegación

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        if (currentWaypoint >= waypoints.Length)
        {
            // Si el bot llega al último punto, regresar al primer punto
            currentWaypoint = 0;
        }

        // Establecer la nueva posición de destino
        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint++;
    }

    private void Update()
    {
        // Comprobar si el bot ha llegado al punto de destino actual
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // Esperar un momento antes de moverse al siguiente punto
            Invoke("MoveToNextWaypoint", 2f);
        }
    }
}
