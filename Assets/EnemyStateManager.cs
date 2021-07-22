using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyPatrol enemyPatrol;
    public EnemyController enemyChasing;
    public FieldOfView fov;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (fov.canSeePlayer)
        {
            enemyChasing.enabled = true;
            enemyPatrol.enabled = false;
        }

        else
        {
            enemyChasing.enabled = false;
            enemyPatrol.enabled = true;
        }
    }
}
