using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    [SerializeField] private float wanderInterval = 14f;

    protected NavMeshAgent agent;

    private Animator anim;
    private bool doWander = false;
    private Vector3 targetPos;

    private void Awake()
    {
        SetComponentVariables();
    }

    private void OnEnable()
    {
        SetComponentVariables();
        StartCoroutine(Wander());
    }

    private void SetComponentVariables()
    {
        anim = GetComponentInChildren<Animator>(true);
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetComponentVariables();
        StartCoroutine(Wander());
    }

    private void Update()
    {
        if (doWander)
        {
            if (!HasTarget())
            {
                agent.SetDestination(targetPos);
            }
            else
            {
                CancelWander();
            }
        }
    }

    private IEnumerator Wander()
    {
        while (true)
        {
            yield return new WaitForSeconds(wanderInterval);
            Debug.Log("Start wander");
            // Set target pos
            targetPos = new Vector3(
                transform.position.x + Random.Range(15f, 25f),
                transform.position.y,
                transform.position.z + Random.Range(15f, 25f));
            targetPos = GameObject.Find("Player").transform.position;

            anim.SetBool("Walking", true);
            agent.enabled = false;
            doWander = true;
        }
    }

    private void CancelWander()
    {
        anim.SetBool("Walking", false);
        agent.enabled = false;
        doWander = false;
    }

    private bool HasTarget()
    {
        if (GetComponent<EnemyAI>() != null)
        {
            //return GetComponent<EnemyAI>().HasTarget();
        }
        return true; // If EnemyAI not found, it's not able to chase, so return true.
    }
}