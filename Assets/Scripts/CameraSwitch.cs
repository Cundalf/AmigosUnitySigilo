using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public CameraController cameraControl;

    void Start()
    {
        cameraControl = FindObjectOfType<CameraController>();
    }

    
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //cameraControl.transform.position = transform.position;
            var interpolationRatio = 1f * Time.deltaTime;
            cameraControl.transform.position = Vector3.Lerp(cameraControl.transform.position, transform.position, interpolationRatio);
        }
    }
}
