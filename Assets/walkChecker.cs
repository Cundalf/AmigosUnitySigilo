using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkChecker : MonoBehaviour
{
    public Transform playerLocation;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, 10) && rayInfo.collider.CompareTag("unwalkable"))
        {
            playerLocation.transform.position = playerLocation.transform.position;
            Debug.DrawLine(ray.origin, rayInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * 100, Color.green);
        }
    }
}
