using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkChecker : MonoBehaviour
{
    public Transform playerLocation;
    public PlayerController playerMovement;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, 100) && rayInfo.collider.CompareTag("unwalkable"))
        {
            playerMovement.canMove = false;
            Debug.DrawLine(ray.origin, rayInfo.point, Color.red);
        }
        else
        {
            playerMovement.canMove = true;
            Debug.DrawLine(ray.origin, ray.direction * 100, Color.green);
        }
    }
}
