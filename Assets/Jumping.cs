using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public PlayerController playerControl;
    public Rigidbody playerRB;
    public Transform targetSalto;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          

            var VectorDireccion = new Vector3 (targetSalto.position.x, targetSalto.position.y + 10f, targetSalto.position.z) - transform.position;
            var VectorFuerza = calcBallisticVelocityVector(transform.position, targetSalto.position, 80);
            Debug.Log($"Vector : {VectorDireccion}");
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
        return velocity*direction.normalized;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("jumpeable"))
        {

            
           
            //playerRB.AddForce(calcBallisticVelocityVector(transform.position, objetivosalto.position, 90));
 
            
        }
    }
}
