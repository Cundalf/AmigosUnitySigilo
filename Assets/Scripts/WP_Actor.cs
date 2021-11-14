using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Actor : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;
    private NavMeshAgent agent;
    public float timeWaitingOnWayPoint;
    public Transform primerWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        //transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("waypoint"))
        {
            target = other.gameObject.GetComponent<WayPoint>().nextPoint;
            Debug.Log("Viaje habitual");
            //transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            StartCoroutine(WaitingAtPosition());
        }

    }

    IEnumerator WaitingAtPosition()
    {
        yield return new WaitForSeconds(timeWaitingOnWayPoint);
        agent.SetDestination(target.position);
    }

    public void ResumeTravel()
    {
        Debug.Log("Se resume el viaje");
        StartCoroutine(WaitingAtPosition());
        agent.SetDestination(target.position);
    }
}
