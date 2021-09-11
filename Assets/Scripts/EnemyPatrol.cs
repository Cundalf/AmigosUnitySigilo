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
    private int destinoAnterior;
    private int destinoSiguiente;
    private int destinoActual;
    public bool outsideBool;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;
        destinoActual = -1;
        //GotoNextPoint();
    }

    private void Update()
    {

    }

    public void GotoNextPoint()
    {


        //!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance

        if (NeedDestination())
        {

                if (points.Length == 0)
                return;

            
            agent.destination = points[GetDestPoint()].position;
            outsideBool = false;



        }




    }

    public bool NeedDestination()
    {
        
        if (agent.destination == Vector3.zero)
        {
            return true;
        }

        var distance = Vector3.Distance(transform.position, agent.destination);
        if (distance <= agent.stoppingDistance)
        {
            return true;
        }

        return false;
    }

    public int GetDestPoint()
    {
        
        destPoint = (destPoint + 1) % points.Length;
        destinoActual = destPoint;

        return destPoint ;
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

