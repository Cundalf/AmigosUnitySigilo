using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;
    public float distanceToTarget;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public Vector3 directionToTarget;

    public bool canSeePlayer;

    public Transform target;
    public Enemy_SM enemyStateManager;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            target = rangeChecks[0].transform;
            Debug.Log($"FOV target pos: {target}");
            directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    enemyStateManager.StateChange(Enemy_SM.EnemyState.Chasing);
                }
                   
                else
                {
                    canSeePlayer = false;
                    Debug.Log("Se cambia el estado nuevamente a patrolling1");
                    enemyStateManager.StateChange(Enemy_SM.EnemyState.Patrolling);
                }
                    
            }
            else
            {
                canSeePlayer = false;
                Debug.Log("Se cambia el estado nuevamente a patrolling2");
                enemyStateManager.StateChange(Enemy_SM.EnemyState.Patrolling);
            }
                
        }
        else if (canSeePlayer)
        {

            canSeePlayer = false;
            Debug.Log("Se cambia el estado nuevamente a patrolling3");
            enemyStateManager.StateChange(Enemy_SM.EnemyState.Patrolling);
        }
            
    }
}
