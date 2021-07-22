using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float distanceLimitToTarget  = 0.5f;
    public bool waitAndSee = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        Debug.Log($"destpoint{destPoint}");
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {

        //Debug.Log($"Distance to point: {distance}");

        
        var distance = Vector3.Distance(transform.position, agent.destination);
        Debug.Log($"distance is: {distance}");



            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {


                GotoNextPoint();

            }
     

       

        // Choose the next destination point when the agent gets
        // close to the current one.

            
    }


    public IEnumerator StayAtPosition()

    {
        yield return new WaitForSecondsRealtime(5);
        waitAndSee = false;
        
        
    }
}

