using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Transform[] destinations;

    public float distanceToFollowPath = 2;

    private int i = 0;

    [Header("--FollowPlayer?--")]

    public bool followPlayer;

    private GameObject player;

    private float distanceToPlayer;

    public float distanceToFollowPlayer = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (destinations == null || destinations.Length == 0)
        { 
            transform.gameObject.GetComponent<AI>().enabled = false;
        }
        else
        {
            navMeshAgent.SetDestination(destinations[0].position);
            player = GameObject.FindGameObjectWithTag("Player");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
