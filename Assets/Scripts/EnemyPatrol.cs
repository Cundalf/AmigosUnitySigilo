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
    public bool llegandoAPunto = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;

        GotoNextPoint();
    }

    private void Update()
    {

    }

    public void GotoNextPoint()
    {


        //Debug.Log($"distancia que le queda al agente{agent.pathPending}");
        Debug.Log($"LLEGANDO AL PUNTO STATE: {llegandoAPunto}");

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {

                // Returns if no points have been set up
                if (points.Length == 0)
                return;
                

                 // Set the agent to go to the currently selected destination.
                agent.destination = points[destPoint].position;
                destPoint = (destPoint + 1) % points.Length;
                //Debug.Log($"destpoint{destPoint}");
                // Choose the next point in the array as the destination,
                // cycling to the start if necessary.

                // Debug.Log("Still Here");      
                if (agent.remainingDistance < 2f)
                {
                llegandoAPunto = true;
                }
        }

    }


    void LateUpdate()
    {
        distance = Vector3.Distance(transform.position, agent.destination);
       


        //Debug.Log($"Distance to point: {distance}");

        //Debug.Log($"WaitAndSee state: {waitAndSee}");

        //Debug.Log($"distance is: {distance}");

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

