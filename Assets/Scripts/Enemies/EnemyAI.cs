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
    public GameObject deathTarget;

    [SerializeField] GameObject creepyFace;
    [SerializeField] GameObject graphics;
    [SerializeField] public Animator anim;

    GameObject soundFX;
    AudioSource footprintsS;

    #region Unity Callback Functions
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ScareEvent(false);
        footprintsS = GetComponent<AudioSource>();
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

        PlayFootstepSound();
    }

    private void OnEnable()
    {
        player = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    #endregion

    private void PlayFootstepSound()
    {
        if (IsWalking() && !footprintsS.isPlaying)
        {
            footprintsS.Play();
        }
        else if (!IsWalking() && footprintsS.isPlaying)
        {
            footprintsS.Stop();
        }
    }

    private bool IsWalking()
    {
        return anim.GetBool(AnimationConstants.ANIM_WALKING);
    }

    public void ScareEvent(bool active)
    {
        if (creepyFace != null)
            creepyFace.SetActive(active);
        if (graphics != null)
            graphics.SetActive(!active);
    }

    void ChasePlayer()
    {
        anim.SetBool(AnimationConstants.ANIM_WALKING, true);

        agent.enabled = true;
        if (player != null)
            agent.SetDestination(player.position);

    }

    void KillingPlayer()
    {

        Destroy(soundFX);
        soundFX = null;

        anim.SetBool(AnimationConstants.ANIM_KILLING, true);
        anim.SetBool(AnimationConstants.ANIM_WALKING, false);
    }

    void Idle()
    {
        Destroy(soundFX);
            soundFX = null;

        anim.SetBool(AnimationConstants.ANIM_WALKING, false);
        agent.enabled = false;
    }

    void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRange, playerMask);

        for (int i = 0; i < colliders.Length; i++) // Make a loop to check whats there
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
}
