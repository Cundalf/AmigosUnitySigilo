using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
    public enum STATE
    {
        IDLE, PATROL, CHASE, ATTACK, SLEEP
    };
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;
    protected FieldOfView enemyFov;
    protected Waypoints patrolRoute;
    //float fireRange = 7f;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Waypoints _patrolRoute, FieldOfView _enemyFov )
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
        enemyFov = _enemyFov;
        patrolRoute = _patrolRoute;
        

    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }
}

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Waypoints _patrolRoute, FieldOfView _enemyFov) : base(_npc, _agent, _anim, _player, _patrolRoute, _enemyFov)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        //if (CanSeePlayer())
        //{
        //    nextState = new Pursue(npc, agent, anim, player);
        //    stage = EVENT.EXIT;
        //}
       if (Random.Range(0, 100) < 10)
        {
            nextState = new Patrol(npc, agent, anim, player,patrolRoute, enemyFov);
            stage = EVENT.EXIT;
        }


    }

    public override void Exit()
    {
        //anim.ResetTrigger("isIdle");
        base.Exit();
    }

}





    public class Patrol : State
    {
        int currentIndex = -1;

        public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Waypoints _patrolRoute, FieldOfView _enemyFOV) : base(_npc, _agent, _anim, _player, _patrolRoute, _enemyFOV)
        {
            name = STATE.PATROL;
            agent.speed = 2;
            agent.isStopped = false;
        }

        public override void Enter()
        {
            currentIndex = 0;


           // anim.SetTrigger("isWalking");
            stage = EVENT.UPDATE;
        }

        public override void Update()
        {

            //if (CanSeePlayer())
            //{
            //    nextState = new Pursue(npc, agent, anim, player);
            //    stage = EVENT.EXIT;
            //}

            if (agent.remainingDistance < 1)
            {
                if (currentIndex >= patrolRoute.Checkpoints.Count - 1)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }

                agent.SetDestination(patrolRoute.Checkpoints[currentIndex].transform.position);
            }


        }

        public override void Exit()
        {
            //anim.ResetTrigger("isWalking");
            stage = EVENT.EXIT;
        }
    }


