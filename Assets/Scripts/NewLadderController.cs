using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLadderController : MonoBehaviour
{
    public bool onLadder;
    public bool exitLadder;
    public float climbSpeed;
    public Vector3 direction;
    private Vector3 velocity;
    private LadderClimbing activeLadder;
    public PlayerMovementNM characterController;
    public float endPoint;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<PlayerMovementNM>();
    }

    // Update is called once per frame
    void Update()
        
    {

        CalculateLadderMovement();
    }

    public void CalculateLadderMovement()
    {
        if (onLadder && !exitLadder)
        {
            characterController.enabled = false;
            characterController.GetComponentInParent<Rigidbody>().useGravity = false;
            float verInput = Input.GetAxis("Vertical");
            
           direction = new Vector3(0, verInput, 0);
           

            //anim.SetFloat("ClimbSpeed", Mathf.Abs(verInput));


            //Debug.Log($"{velocity}");
            transform.Translate(direction);
            //transform.position += direction * climbSpeed;
            Debug.Log($"{transform.position}");


        }
    }

    public void OnLadder(Vector3 position, LadderClimbing currentLadder)
    {
        //animation.SetBool("onLadder", true)
        //animation.SetFloat("Speed", 0f)
        //va a tomar la position que le pasa el script de la escalera como posicion de inicio.
        transform.position = position;
        //Guarda cual es  escalera activa.
        activeLadder = currentLadder;
        onLadder = true;
    }

}
