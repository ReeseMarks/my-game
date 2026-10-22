using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    // Activity 14 - Variables
    public Transform[] patrolPoints;
    private int patrolIndex = 0;
    public float waypointTolerance = 1.0f;
    public float detectionRange = 6.0f;
    public float loseRange = 10.0f;

    private enum EnemyState
    {
        Patrol,
        Chase
    }

    private EnemyState currentState = EnemyState.Patrol;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(player != null && agent != null && agent.isOnNavMesh)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if(currentState == EnemyState.Chase && distance >= loseRange)
            {
                currentState = EnemyState.Patrol;
                Debug.Log("Player lost, return to patrol.");
            }

            if(currentState == EnemyState.Patrol && distance <= detectionRange)
            {
                currentState = EnemyState.Chase;
                Debug.Log("Player detected!");
            }

            if(currentState == EnemyState.Patrol)
            {
                Patrol();
            }
            else if(currentState == EnemyState.Chase)
            {
                Chase();
            }
        }
    }

    private void Patrol()
    {
        if(patrolPoints.Length == 0) return;

        Transform destination = patrolPoints[patrolIndex];
        agent.SetDestination(destination.position);

        if(!agent.pathPending && agent.remainingDistance <= waypointTolerance)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }
}
