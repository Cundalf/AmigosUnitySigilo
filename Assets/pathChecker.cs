using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathChecker : MonoBehaviour
{
    public Transform playerLocation;
    public PlayerController playerControl;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, 100) && rayInfo.collider.CompareTag("walkable"))
        {
            playerControl.canMoveForward = true;
            Debug.DrawLine(ray.origin, rayInfo.point, Color.green);
        }
        else
        {
            playerControl.canMoveForward = false;
            Debug.DrawLine(ray.origin, ray.direction * 100, Color.red);
        }
    }
}
