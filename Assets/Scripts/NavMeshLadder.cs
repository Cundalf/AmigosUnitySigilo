using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshLadder : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool MoveAcrossNavMeshesStarted;
    public float factorSpeed;
    public AgentLinkMover agentLinkMover;
    public bool climbingActivated;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ladder") && Input.GetKey(KeyCode.Space))
            {
            agentLinkMover.enabled = false;
            climbingActivated = true;
            
        }
    }
    private void Update()
    {
        
        if (agent.isOnOffMeshLink && !MoveAcrossNavMeshesStarted && climbingActivated)
        {
            StartCoroutine(MoveAcrossNavMeshLink());
            MoveAcrossNavMeshesStarted = true;
            agent.autoTraverseOffMeshLink = false;

        }
    }
    
    


    IEnumerator MoveAcrossNavMeshLink()
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        agent.updateRotation = false;

        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float duration = (endPos - startPos).magnitude / agent.speed * factorSpeed;
        float t = 0.0f;
        float tStep = 1.0f / duration;
        while (t < 1.0f)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t);
            agent.destination = transform.position;
            t += tStep * Time.deltaTime;
            yield return null;
        }


        transform.position = endPos;
        agent.updateRotation = true;
        agent.CompleteOffMeshLink();
        MoveAcrossNavMeshesStarted = false;
        agent.autoTraverseOffMeshLink = true;
        agentLinkMover.enabled = true;
        climbingActivated = false;
    }
}
