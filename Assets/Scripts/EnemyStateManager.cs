using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{


    public EnemyPatrol enemyPatrol;
    public EnemyController enemyChasing;
    public FieldOfView fov;
    public float enemyWaitingAtPosition = 1f;

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
    }

    private void Update()
    {

        
        switch(currentEnemyState)
        {
            case EnemyState.Walking:

                //enemyPatrol.enabled = true;
                
                if(enemyPatrol.llegandoAPunto)
                {
                    enemyPatrol.llegandoAPunto = false;
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

                    //Debug.Log("fuera del if");
                    StartCoroutine(WaitingAndWatching());
                    
                    //Debug.Log("esperando");






                break;
            case EnemyState.Chasing:
                enemyChasing.enabled = true;
                if(!fov.canSeePlayer)
                {
                    enemyChasing.enabled = false;
                    //currentEnemyState = EnemyState.Walking;
                }
                break;

        }
    }

    public IEnumerator WaitingAndWatching()
    {
        //enemyPatrol.enabled = false;
        yield return new WaitForSeconds(enemyWaitingAtPosition);
        currentEnemyState = EnemyState.Walking;
        

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
