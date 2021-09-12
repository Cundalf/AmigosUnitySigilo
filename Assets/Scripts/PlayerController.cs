using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public bool canMoveForward;
    public bool canMoveBackward;
    public Transform frontGroundCheck;
    public Transform backGroundCheck;
    [Range(0,0.5f)]
    public float frontGroundCheck_offset = 1f;
    [Range(0, 0.5f)]
    public float backFGroundCheck_offset= 1f;

    private void Start()
    {
        frontGroundCheck.position = transform.position + new Vector3(0, 0, frontGroundCheck_offset);
        backGroundCheck.position = transform.position - new Vector3(0, 0, backFGroundCheck_offset);
    }

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;


        // Make it move 10 meters per second instead of 10 meters per frame...


        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Se va a mover hacia delante sólo cuando el booleano se active. Y esta activación dependerá del pathChecker
        if (canMoveForward && translation > 0.0)
        {
            transform.Translate(0, 0, translation);
        }
        // Se va a mover hacia delante sólo cuando el booleano se active. Y esta activación dependerá del pathChecker que detecta en la espalda del personaje.
        if (canMoveBackward && translation < 0.0)
        {
            transform.Translate(0, 0, translation);
        }

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
    }
}
