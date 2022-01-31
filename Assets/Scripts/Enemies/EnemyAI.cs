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

    [SerializeField]
    public Animator anim;


    public GameObject deathTarget;
    [SerializeField]
    GameObject creepyFace;
    [SerializeField]
    GameObject graphics;

    [SerializeField]
    GameObject footSND;
    GameObject soundFX;

    AudioSource footprintsS;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ScareEvent(false);
        footprintsS = GetComponent<AudioSource>();
    }

    public void ScareEvent(bool active)
    {
        if(creepyFace != null)
            creepyFace.SetActive(active);
        if(graphics != null)
        graphics.SetActive(!active);
    }

    void Update()
    {
        if(DeathManager.Instance.alive)
        {
            if (player != null)
            {
                ChasePlayer();
            }
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

        if (!footprintsS.isPlaying && anim.GetBool("Walking")) {
            footprintsS.Play();
        }
        else if (!anim.GetBool("Walking"))
        {
            footprintsS.Stop();
        }
    }

    private void OnEnable()
    {
        player = null;
    }

    void ChasePlayer()
    {
        anim.SetBool("Walking", true);

        //if (soundFX == null)
        //    soundFX = Instantiate(footSND, GameObject.Find("Player").transform);

        agent.enabled = true;
        if (player != null)
            agent.SetDestination(player.position);

    }

    void KillingPlayer()
    {

        Destroy(soundFX);
        soundFX = null;

        anim.SetBool("Killing", true);
        anim.SetBool("Walking", false);
    }

    void Idle()
    {
        Destroy(soundFX);
            soundFX = null;

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
