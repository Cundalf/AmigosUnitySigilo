using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaType : MonoBehaviour
{

    public OffMeshLinkData data;
    public NavMeshAgent agent;
    public NavMeshLinkData NMData;
    public float linkSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{data.offMeshLink.area}");
        Debug.Log($"{NMData.area}");
    }
}
