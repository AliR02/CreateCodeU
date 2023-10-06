using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform player; // Reference to the player's transform.
    public float pursueDistance = 10f; // Distance at which the enemy starts pursuing the player.
    public float senseRange = 15f; // The range at which the enemy can sense the player.

    private int m_CurrentWaypointIndex;
    private Vector3 originalPosition; // Store the enemy's original position.

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position; // Store the enemy's starting position.
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within pursueDistance.
        if (distanceToPlayer <= pursueDistance)
        {
            // Stop patrolling and pursue the player.
            navMeshAgent.SetDestination(player.position);
            m_CurrentWaypointIndex = waypoints.Length; // Set an invalid waypoint index.
        }
        else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // Resume patrolling if not pursuing and reached a waypoint.
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a wire sphere to visualize the sensing range.
        Gizmos.color = Color.red; // You can change this color to any desired color.
        Gizmos.DrawWireSphere(transform.position, senseRange);
    }
}