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


    public GameObject deathTarget;
    [SerializeField]
    GameObject creepyFace;
    [SerializeField]
    GameObject graphics;
    

    void Start()
    {
        deathScript = GameObject.Find("DeathManager").GetComponent<DeathScript>();
        agent = GetComponent<NavMeshAgent>();
        ScareEvent(false);
    }

    public void ScareEvent(bool active)
    {
        creepyFace.SetActive(active);
        graphics.SetActive(!active);
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
                if (player == null && GetComponent<EnemyAggro>() != null) GetComponent<EnemyAggro>().PlayEnemyAggroSound();

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
}
