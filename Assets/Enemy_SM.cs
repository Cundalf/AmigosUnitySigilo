using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SM : MonoBehaviour

{

    public WP_Actor enemyPatrolling;
    public FieldOfView enemyDetection;
    public EnemyController enemyChasing;




    public enum EnemyState
    {

        Patrolling,
        Chasing,
    }

    public EnemyState currentEnemyState;
    // Start is called before the first frame update
    void Start()
    {
        enemyPatrolling.enabled = true;
        enemyDetection.enabled = true;
        enemyChasing.enabled = false;
    }

    private void Update()
    {


        switch (currentEnemyState)
        {


            case EnemyState.Patrolling:
                enemyPatrolling.enabled = true;
                enemyChasing.enabled = false;
                if(enemyDetection.canSeePlayer)
                {
                    currentEnemyState = EnemyState.Chasing;
                }

                break;
            case EnemyState.Chasing:
                
                enemyChasing.enabled = true;
                enemyPatrolling.enabled = false;

                if (!enemyDetection.canSeePlayer)
                {
                    currentEnemyState = EnemyState.Patrolling;
                }
                break;

        }
    }
}
