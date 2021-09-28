using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondCameraController : MonoBehaviour
{
    public Camera secondCamera;
    public GameObject player;

    private void FixedUpdate()
    {
        secondCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, secondCamera.transform.position.z);
        //You dont want the camera's z position to be the same as the player, just the x and y.
        //Locks camera position to the centre of the player
    }
}
