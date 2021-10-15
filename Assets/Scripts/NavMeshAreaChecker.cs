using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshAreaChecker : MonoBehaviour
{
   // public Transform target;
    private NavMeshAgent agent;
    private int waterMask;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waterMask = 4 << NavMesh.GetAreaFromName("Climb");
        //agent.SetDestination(target.position);
    }

    void Update()
    {
        NavMeshHit hit;

        // Check all areas one length unit ahead.
        if (!agent.SamplePathPosition(NavMesh.AllAreas, 1.0F, out hit))
            if ((hit.mask & waterMask) != 0)
            {
                Debug.Log("On surface");
                // Water detected along the path...
            }
    }
}
