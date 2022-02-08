using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;
    float visDist;
    float visAngle;
    Waypoints patrolRoute;
    FieldOfView enemyFov;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        enemyFov = this.GetComponent<FieldOfView>();
        patrolRoute = this.GetComponent<Waypoints>();
        
        currentState = new Idle(this.gameObject, agent, anim, player, patrolRoute, enemyFov);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
