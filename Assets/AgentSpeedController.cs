using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentSpeedController : MonoBehaviour
{
  
    
   
    [SerializeField] NavMeshAgent agent ;
    public pruebaCheck prueba;
    NavMeshHit navHit;
    OffMeshLink offMesh;
    NavMeshLinkData NMData;
    public float linkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        if (agent.isOnOffMeshLink)
        {

        }
        
        //endPos = data.endPos + Vector3.up * agent.baseOffset;
        // if (agent.isOnOffMeshLink)
        //{

        //    Debug.Log();
        //    agent.speed = agent.speed * linkSpeed;
        //}





        //Debug.Log($"{NMData.area}");
        // Debug.Log($"{data.linkType}");

        // if (agent.isOnOffMeshLink)
        //{


        //     agent.speed = agent.speed * linkSpeed;
        //}
        //     


        //NavMeshHit navMeshHit;
        //if (NavMesh.SamplePosition(agent.transform.position, out navMeshHit, 0.1f,8))
        //{
        //    Debug.Log(navMeshHit.mask);
        //}


        agent.SamplePathPosition(-1, 4f, out navHit);
        //Debug.Log(navHit.mask);

        if (navHit.mask == 8)
        {
            agent.speed = 0.1f;
        }
    }
}
