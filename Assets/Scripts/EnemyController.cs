using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public FieldOfView fov;
    public Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        fov = GetComponent<FieldOfView>();
        target = GetComponent<FieldOfView>().playerRef.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fov.canSeePlayer)
        {
            agent.SetDestination(target.position);
           // Debug.Log("True condition chase should start");
        }

        if (fov.distanceToTarget < agent.stoppingDistance)

        {
            FaceTarget();
        }
    }


    void FaceTarget()
    {
        Vector3 direction = fov.directionToTarget;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
