using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    protected NavMeshAgent agent;
    public float sightRange;

    private Collider closestTarget;

    public LayerMask playerMask = 6;
    float distance = 99;

    bool playerInSightRange;

    void Start()
    {
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(player != null)
            ChasePlayer();
        else
        {
            Idle();
        }

        FindTarget();


        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
    }
    void ChasePlayer()
    {
        agent.enabled = true;
        if (player != null)
            agent.SetDestination(player.position);

    }

    void Idle()
    {
        agent.enabled = false;
    }

    void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRange, playerMask);

        for (int i = 0; i < colliders.Length; i++) //make a loop to check whats there
        {
            float distToTarget = Vector3.Distance(colliders[i].transform.position, transform.position);

            if (distToTarget < sightRange)
            {
                player = colliders[i].transform;
            }
            else
                player = null;
        }
    }

    void ResetTarget()
    {
        distance = 99;
        player = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
