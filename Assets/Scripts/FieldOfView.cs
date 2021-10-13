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

    private void Start()
    {
        //Cambio a playerRef por una referencia al objeto arrojado.
        //playerRef = GameObject.FindGameObjectWithTag("Player");
        //playerRef = GameObject.FindGameObjectWithTag("thrown");
        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {
        playerRef = GameObject.FindGameObjectWithTag("thrown");
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            
            yield return wait;
            FieldOfViewCheck();
            Debug.Log($"{canSeePlayer}");
        }
    }

    private void FieldOfViewCheck()
    {
       
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            directionToTarget = (target.position - transform.position).normalized;
            
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;

            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
