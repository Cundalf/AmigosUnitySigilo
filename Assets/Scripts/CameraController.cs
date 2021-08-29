using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotateSpeed = 90;
    public bool rotationState;
    public float targetValue;
    public float marginValue;
    public float maxAngle = 360;
    public float distance;
    public GameObject player;
    private Vector2 player_prev_position;
    public Collider colliderBaseLevel;
    public Camera mainCamera;
    public bool distantCamera  =false;
    public float cameraSmooth = 5;
    public float distantSize = 10f;
    public float closerSize = 2f;
    private Vector3 lastSeenPos;
    public float camOffset;
    public float cameraYangle = 0f;
    public GameObject[] tps;
    private float distanceAngles;





    private void Start()
    {
        distantCamera = true;
        transform.position = colliderBaseLevel.bounds.center;
        rotationState = false;
        marginValue = 0.3f;
        targetValue = 1f;

        
    }

    // Applies a rotation of 90 degrees per second around the Y axis
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Se activa el booleano de rotaci�n y se setea el angulo objetivo 
            rotationState = true;
            targetValue = transform.eulerAngles.y + 90f;
        }
        RotateSelf();
        //Debug.Log($"transform euler angle y is: {transform.eulerAngles.y} and target value is : {targetValue}");

        if (Input.GetKeyDown(KeyCode.C))
        {
            distantCamera = !distantCamera;
        }

        if (distantCamera)
        {
            transform.position = Vector3.Lerp(transform.position, colliderBaseLevel.bounds.center, Time.deltaTime * cameraSmooth);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, distantSize, Time.deltaTime * cameraSmooth);

            TP_ChangeState();

            //transform.position = colliderBaseLevel.bounds.center;
            //lastSeenPos = player.transform.position;
        }

        

        //if (distantCamera && transform.rotation.eulerAngles.y == cameraYangle)
        //{
        //    
        //}

        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * cameraSmooth) ;
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, closerSize, Time.deltaTime * cameraSmooth);
            TP_ChangeState();
        }
        Debug.Log("Camera toggle called");


        //if (Vector2.Distance(player.transform.position, transform.position) > 4.5)
        //{
        //    Vector2 delta_position;
        //    delta_position = (Vector2)player.transform.position - player_prev_position;
        //    transform.Translate(delta_position);
        //}
        //player_prev_position = player.transform.position;

    }


    public void RotateSelf()
    {
        //se calcula la distancia entre el �ngulo actual y el �ngulo objetivo

        distance = Mathf.Abs(transform.eulerAngles.y - targetValue);

        //Si el estado de rotaci�n se activa entra al if
        if (rotationState)
        {
            // Si la distancia entre el �ngulo de rotaci�n actual es cercano al �ngulo m�ximo dentro de un margen de error o si el valor objetivo est� por encima del 
            // del �ngulo m�ximo de giro, el valor objetivo se vuelve 0.

            if (Mathf.Abs(transform.eulerAngles.y - maxAngle) <= marginValue || targetValue > maxAngle)
            {
                targetValue = 0;
            }
            // se realiza el giro
            float angle = rotateSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.up);
        }


        // Si el valor de la variable distance cae dentro del margen aceptado y el estado de rotaci�n es true, se apaga el estado de rotaci�n.
        if (distance <= marginValue && rotationState)
        {

            Debug.Log("Stop condition activate");
            rotationState = false;
        }

    }

    public void TP_ChangeState()
    {
        distanceAngles = Mathf.Abs(cameraYangle - transform.rotation.eulerAngles.y);
        if (distantCamera && distanceAngles < 0.01f)
        {

            foreach (GameObject tp in tps) //the line the error is pointing to
            {
                tp.SetActive(true);
            }
        }

        else
        {
            foreach (GameObject tp in tps) //the line the error is pointing to
            {
                tp.SetActive(false);
            }
        }
    }


}
