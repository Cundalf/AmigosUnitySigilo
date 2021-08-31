using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{

    public Transform[] points;
    public int destPoint = 0;
    private NavMeshAgent agent;
    public float distanceLimitToTarget  = 0.5f;
    public bool waitAndSee = true;
    public float distance;
    public EnemyStateManager currentState;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;

        GotoNextPoint();
    }


    public void GotoNextPoint()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {

                // Returns if no points have been set up
                if (points.Length == 0)
                return;
                
                agent.destination = points[destPoint].position;
                // Set the agent to go to the currently selected destination.

                Debug.Log($"destpoint{destPoint}");
                // Choose the next point in the array as the destination,
                // cycling to the start if necessary.
                destPoint = (destPoint + 1) % points.Length;
                Debug.Log("Still Here");      
        }

    }


    void LateUpdate()
    {

        //Debug.Log($"Distance to point: {distance}");

        //Debug.Log($"WaitAndSee state: {waitAndSee}");
        distance = Vector3.Distance(transform.position, agent.destination);
        Debug.Log($"distance is: {distance}");

        //if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        //{

        //        //GotoNextPoint();

        //}
      
        // Choose the next destination point when the agent gets
        // close to the current one.

            
    }


    public IEnumerator StayAtPosition()

    {
        yield return new WaitForSeconds(3);
        


    }
}

