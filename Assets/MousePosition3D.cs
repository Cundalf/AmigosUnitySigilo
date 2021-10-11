using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject mousePointer;
    private Vector3 positionOnClick;
    public float factor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            positionOnClick = Input.mousePosition;
        }
        Ray ray = mainCamera.ScreenPointToRay(positionOnClick);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                mousePointer.transform.position = raycastHit.point;
            var VectorFuerza = calcBallisticVelocityVector(transform.position, targetSalto.position, 85);
            instatiatedObject
            playerRB.AddForce(VectorFuerza, ForceMode.Impulse);

        }


    }


    Vector3 calcBallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        // calculate velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized * factor;
    }
}
