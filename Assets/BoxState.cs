using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxState : MonoBehaviour
{
    public BoxState otherCube;
    public bool thisIsEntrance;
    public bool playerHere;
    public bool playerLeft;
    public float speed = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !otherCube.thisIsEntrance)
        {
           
            thisIsEntrance = true;
            other.GetComponent<PlayerController>().enabled = false;
            other.transform.position = new Vector3(otherCube.transform.position.x, otherCube.transform.position.y, otherCube.transform.position.z);
            otherCube.enabled = false;

        }

    }

    public void OnTriggerExit(Collider other)
        {
        thisIsEntrance = false;
        }

    public void Movement()
    {         // Get the horizontal and vertical axis.
              // By default they are mapped to the arrow keys.
              // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;


        // Make it move 10 meters per second instead of 10 meters per frame...


        translation *= Time.deltaTime;


        // Se va a mover hacia delante sólo cuando el booleano se active. Y esta activación dependerá del pathChecker
        //transform.Translate(otherCube.transform.position);

    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(1);

    }
}


