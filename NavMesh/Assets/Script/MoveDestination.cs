using UnityEngine;
using UnityEngine.AI;

public class MoveDestination : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
