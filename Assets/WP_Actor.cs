using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Actor : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;
    private NavMeshAgent agent;
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
            //transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            StartCoroutine(WaitingAtPosition());
        }

    }

    IEnumerator WaitingAtPosition()
    {
        yield return new WaitForSeconds(5);
        agent.SetDestination(target.position);
    }
}
