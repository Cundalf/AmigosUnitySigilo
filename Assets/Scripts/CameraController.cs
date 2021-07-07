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




    private void Start()
    {
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
        Debug.Log($"transform euler angle y is: {transform.eulerAngles.y} and target value is : {targetValue}");



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
}
