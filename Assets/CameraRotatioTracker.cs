using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatioTracker : MonoBehaviour
{
    public Transform rotationState;
    private float yAngleVal;
    private int yAngleRounded;
  

    void Start()
    {

    }
    private void Update()
    {
        yAngleVal = rotationState.rotation.eulerAngles.y;
      
       // RotationState();
    }

    //public void  RotationState()
    //{
        
    //    if (Mathf.Round(yAngleVal) == 0)

    //        Debug.Log("Estoy en rotacion 0");
            
    //    else if (Mathf.Round(yAngleVal) == 90)
    //        Debug.Log("Estoy en rotacion 90");
    //    else if (Mathf.Round(yAngleVal) == 180)
    //        Debug.Log("Estoy en rotacion 180");
    //    else if (Mathf.Round(yAngleVal) == 270)
    //        Debug.Log("Estoy en rotacion 270");
        
    //}
}

