using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{


    public EnemyPatrol enemyPatrol;
    public EnemyController enemyChasing;
    public FieldOfView fov;
    public float enemyWaitingAtPosition = 1f;
    private NavMeshAgent agent;
    public bool esperando;
    public Vector3 destinoAnterior;
    public int destinoAnteriorB;


    public enum EnemyState
    {
        Walking,
        Patrolling,
        Chasing,
    }

    public EnemyState currentEnemyState;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyState = EnemyState.Walking;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        
        switch(currentEnemyState)
        {
            case EnemyState.Walking:

                //enemyPatrol.enabled = true;

                //Debug.Log($"El destino del agente fuera del if es: {enemyPatrol.destPoint}");

                //agent.remainingDistance < 2f && !esperando && enemyPatrol.destPoint != destinoAnteriorB

                if (!enemyPatrol.NeedDestination() && agent.remainingDistance < 2f && !esperando)
                {
                    if (enemyPatrol.GetDestPoint() == destinoAnteriorB)
                    
                        return;
                  
                    destinoAnteriorB = enemyPatrol.destPoint;
                    esperando = true;
                    currentEnemyState = EnemyState.Patrolling;
                    
                }
                
                else
                {
                    
                    enemyPatrol.GotoNextPoint();
                    
                }
              

                if (fov.canSeePlayer)
                {
                    //enemyPatrol.enabled = false;
                    currentEnemyState = EnemyState.Chasing;
                }
                break;




             case EnemyState.Patrolling:

                 
                    StartCoroutine(WaitingAndWatching());
                    
                






                break;
            case EnemyState.Chasing:
                enemyChasing.enabled = true;
                //if(!fov.canSeePlayer)
                //{
                //    enemyChasing.enabled = false;
                //    //currentEnemyState = EnemyState.Walking;
                //}
                //break;

                StartCoroutine(WaitingAndWatching());
                break;
        }
    }

    public IEnumerator WaitingAndWatching()
    {
        //enemyPatrol.enabled = false;
        var tiempoInicio = Time.time;
        yield return new WaitForSeconds(enemyWaitingAtPosition);
        var tiempoFin = Time.time - tiempoInicio;
        //Debug.Log($"Tiempo transcurrido esperando {tiempoFin}");
        esperando = false;
        enemyPatrol.outsideBool = true;
        currentEnemyState = EnemyState.Walking;
        //Debug.Log("Esperando");
        

    }

    public IEnumerator GivingTimeToMove()
    {
        yield return new WaitForSeconds(3f);
        esperando = true;
    }

    public IEnumerator GivingTimeToMoveB()
    {
        yield return new WaitForSeconds(1f);
        
    }
    //// Update is called once per frame
    //void Update()
    //{
    //    if  (fov.canSeePlayer)
    //    {
    //        enemyChasing.enabled = true;
    //        enemyPatrol.enabled = false;
    //    }

    //    else
    //    {
    //        enemyChasing.enabled = false;
    //        enemyPatrol.enabled = true;
    //    }
    //}


}
