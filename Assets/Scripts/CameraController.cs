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
        //Comienza en la cámara más lejana y además setea el transform de la camara al centro del collider base del nivel.
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
            //Se activa el booleano de rotación y se setea el angulo objetivo 
            rotationState = true;
            targetValue = transform.eulerAngles.y + 90f;
        }
        RotateSelf();
        //Debug.Log($"transform euler angle y is: {transform.eulerAngles.y} and target value is : {targetValue}");

        if (Input.GetKeyDown(KeyCode.C))
        {
            // Un toggle sencillo del booleano que controla si estamos en la camara de lejos o de cerca
            distantCamera = !distantCamera;
        }

        if (distantCamera)
        {
            /*Si pasamos a la camara lejana hacemos un lerp entre la posicion actual de la camara y el centro del collider base del nivel
             * Ademas hacemos un LERP entre el tamaño que tenga el sensor ortografico de la camara y el tamaño que deberia tener 
             * en la camara distante
            */
            transform.position = Vector3.Lerp(transform.position, colliderBaseLevel.bounds.center, Time.deltaTime * cameraSmooth);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, distantSize, Time.deltaTime * cameraSmooth);

            TP_ChangeState();

        }

        


        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * cameraSmooth) ;
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, closerSize, Time.deltaTime * cameraSmooth);
            TP_ChangeState();
        }
       // Debug.Log("Camera toggle called");

        // Dejo este codigo aca por si necesitamos hacer que la camara se mueve en puntos fijos cuando estamos en la camara cercana

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
        //se calcula la distancia entre el ángulo actual y el ángulo objetivo

        distance = Mathf.Abs(transform.eulerAngles.y - targetValue);


        //Si el estado de rotación se activa entra al if
        if (rotationState)
        {
            // Si la distancia entre el ángulo de rotación actual es cercano al ángulo máximo dentro de un margen de error o si el valor objetivo está por encima del 
            // del ángulo máximo de giro, el valor objetivo se vuelve 0.

            if (Mathf.Abs(transform.eulerAngles.y - maxAngle) <= marginValue || targetValue > maxAngle)
            {
                targetValue = 0;
            }
            // se realiza el giro
            float angle = rotateSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.up);
        }


        // Si el valor de la variable distance cae dentro del margen aceptado y el estado de rotación es true, se apaga el estado de rotación.
        if (distance <= marginValue && rotationState)
        {

            Debug.Log("Stop condition activate");
            rotationState = false;
        }

    }

    public void TP_ChangeState()
    {
        /* Esta funcion calcula el angulo entre el eje y de la camara y el angulo para el eje y que seteamos como deseado para habilitar los teleport
         * lo puse como distance porque los valores puntuales no son compatibles con el giro de camara ya que a veces varia en algún decimal y no se habilitan
         * los teleport entonces es mejor setearlo como una condicion de "distancia menor a cierto limite" el limite esta hardcodeado pero puede ser otra variable
         * mas del editor
         * 
         */
        if (tps.Length != 0)
        {

            distanceAngles = Mathf.Abs(cameraYangle - transform.rotation.eulerAngles.y);
            if (distantCamera && distanceAngles < 0.01f)

            //Solo se habilita el tp en la camara distante y con la condicion de angulo de camara deseado
            {

                foreach (GameObject tp in tps)
                {
                    tp.SetActive(true);
                }
            }

            else
            {
                foreach (GameObject tp in tps)
                {
                    tp.SetActive(false);
                }
            }
        }
    }

}
