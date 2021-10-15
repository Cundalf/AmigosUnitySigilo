using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pruebaCheck : MonoBehaviour
{
    NavMeshLink navMesh;

    private void Start()
    {
        navMesh = GetComponent<NavMeshLink>();
        Debug.Log($"{navMesh.area}");
    }
}
