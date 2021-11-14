using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public FieldOfView fov;
    public Transform target;
    NavMeshAgent agent;
    public Transform itemArrojable;
    public Transform targetFromFOV;


    // Start is called before the first frame update
    void Start()
    {
        fov = GetComponent<FieldOfView>();
        //Cuando se inicializa el script toma al gameobject del player como referencia de target. Esto se tiene que cambiar para que el 
        //Enemigo apunte a lo que le tiremos. 

        target = GetComponent<FieldOfView>().target;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (fov.canSeePlayer && target != null)
        {

            target.position = fov.target.position;
            agent.SetDestination(target.position);
            agent.stoppingDistance = 2f;
           
           // Debug.Log("True condition chase should start");
        }

        if(!fov.canSeePlayer)
        {
            target = GetComponent<FieldOfView>().playerRef.transform;
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
