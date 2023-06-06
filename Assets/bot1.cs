using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot1 : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public GameObject point1;

    public GameObject point2;

    private bool goingToFirstPoint = true;

    // Start is called before the first frame update
    void Start()
    {
        SetDestination(point2);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.5f && !navMeshAgent.pathPending)
        {
            if (goingToFirstPoint)
            {
                SetDestination(point2);
            }
            else
            {
                SetDestination(point1);
            }

            goingToFirstPoint = !goingToFirstPoint;
        }
    }

    void SetDestination(GameObject destination)
    {
        navMeshAgent.SetDestination(destination.transform.position);
    }
}
