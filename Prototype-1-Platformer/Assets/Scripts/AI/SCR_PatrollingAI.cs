using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_PatrollingAI : MonoBehaviour
{
    [Header("References")]
    public Transform[] patrolPoints;
    public NavMeshAgent agent;
    public GameObject player;
    private int currentPoint = 0;
    private bool goBack;
    [Header("AI Damage Settings")]
    public int aiDamageAmount;
    public int aiDamageDelay;
    [Header("AI Checks")]
    public bool playerInRange;
    private bool canDamage;
    [Header("AI Health")]
    public float health = 25f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        if(health == 0)
        {
            Destroy(gameObject);
        }

    }

    public void GoToNextWaypoint()
    {
        if (!goBack)
        {
            if (currentPoint == patrolPoints.Length - 1)
            {
                goBack = true;
            }

            currentPoint++;

            agent.destination = patrolPoints[currentPoint].position;
        }
        else if (goBack)
        {
            if (currentPoint == 0)
            {
                goBack = false;
            }

            currentPoint = 0;
            agent.destination = patrolPoints[currentPoint].position;
        }

    }

    private void DealDamage()
    {
        if (agent.remainingDistance <= .5)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(aiDamageAmount);
        }
    }

    public void AttackingState()
    {
        agent.SetDestination(player.transform.position);

        InvokeRepeating("DealDamage", aiDamageDelay, aiDamageDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            health -= 25f;
        }
    }
}
