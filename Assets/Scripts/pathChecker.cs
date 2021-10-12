using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathChecker : MonoBehaviour
{
    public Transform playerLocation;
    public PlayerController playerControl;

    // Este codigo reemplaza el antiguo walkChecker. Accede al playerMovement y si no hay nada "caminable" delante bloquea el avance SOLO en esa dirección.
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, 100) && (rayInfo.collider.CompareTag("walkable")|| rayInfo.collider.CompareTag("jumpeable") || rayInfo.collider.CompareTag("Ladder") || rayInfo.collider.CompareTag("throwable")))
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
