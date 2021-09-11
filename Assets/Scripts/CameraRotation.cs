using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //public Transform player;
    //public float smoothSpeed = 0.125f;
    //public float rotateSpeed;
    //public Vector3 offset;
    //private Vector3 velocity = Vector3.zero;
    //private float rotationAngle = 90f;
    //private bool isRotate = false;
    private bool Lerping;
    private float MoveDuration = 1f;


    //void LateUpdate()
    //{
    //transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, smoothSpeed * Time.deltaTime);
    //}

    // void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        transform.RotateAround(player.position, Vector3.up, rotationAngle);

    //    }
    //    CompleteRotation();
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        transform.RotateAround(player.position, -Vector3.up, rotationAngle);
    //    }
    //}

    //void CompleteRotation()
    //{

    //}


    void Update()
        {
            if (Lerping) return;

            if (Input.GetKeyDown(KeyCode.Q)) StartCoroutine(Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y+ 90, 0)));
            if (Input.GetKeyDown(KeyCode.E)) StartCoroutine(Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y -90, 0)));
           // Debug.Log($"transform rotation : {transform.rotation}");
    }

        private IEnumerator Slerp(Quaternion StartRot, Quaternion EndRot)
        {
            Lerping = true;

            // Time since started lerping
            float TimeElapsed = 0;

            // do a while loop so the noramalized time goes past 1 on the last iteration
            // placing you at the endrot before ending
            do
            {
                TimeElapsed += Time.deltaTime;
                float NormalizedTime = TimeElapsed / MoveDuration;

                transform.rotation = Quaternion.Slerp(StartRot, EndRot, NormalizedTime);

                // Wait for one frame
                yield return null;
            }
            while (TimeElapsed < MoveDuration);

            // Lerping is done
            Lerping = false;
        }
    }
