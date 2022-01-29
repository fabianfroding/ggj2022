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

    bool playerInSightRange;

    DeathScript deathScript;
    [SerializeField]
    public Animator anim;

    void Start()
    {
        deathScript = GameObject.Find("DeathManager").GetComponent<DeathScript>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(deathScript.alive)
        {
            if (player != null)
                ChasePlayer();
            else
            {
                Idle();
            }

            FindTarget();

            //playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        }
        else
        {
            agent.enabled = false;
            KillingPlayer();
        }

    }

    private void OnEnable()
    {
        player = null;
        //print("Hey brah");
    }

    void ChasePlayer()
    {
        anim.SetBool("Walking", true);

        agent.enabled = true;
        if (player != null)
            agent.SetDestination(player.position);

    }

    void KillingPlayer()
    {
        anim.SetBool("Killing", true);
        anim.SetBool("Walking", false);
    }

    void Idle()
    {
        anim.SetBool("Walking", false);
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public bool HasTarget()
    {
        return player != null;
    }
}
