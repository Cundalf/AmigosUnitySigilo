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
        //Con este target el enemigo se moverá a la dirección del player pero nosotros queremos que se mueva al objeto arrojado por esto
        //cambiamos a playerRef en el script de field of view
        target = GetComponent<FieldOfView>().playerRef.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fov.canSeePlayer)
        {
            agent.SetDestination(target.position);
            agent.stoppingDistance = 2f;
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
