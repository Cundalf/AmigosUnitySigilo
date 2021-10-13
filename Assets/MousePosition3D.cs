using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject mousePointer;
    [SerializeField] private GameObject ObjetoDisparado;
    [SerializeField] private Transform firePointPosition;
    [SerializeField] public Inventory playerInventory;
    private GameObject instatiatedObject;
    private Vector3 FuerzaDisparo;
    private Vector3 positionOnClick;
    public float factor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Primero se comprueba que el item est� en el inventario.
        checkInventory();

        if (Input.GetMouseButtonDown(0) && playerInventory.gotItem)
        {
            //Se activa cuando toco el click izquiero y adem�s tengo un item en el inventario. Cuando se integre el movimiento por nodos seguramente
            //tenga que agregar una condici�n m�s de tener alguna tecla apretada adem�s del click para lanzar el objeto.


            positionOnClick = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(positionOnClick);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                //mousePointer.transform.position = raycastHit.point;
                FuerzaDisparo = calcBallisticVelocityVector(firePointPosition.position, raycastHit.point, 60);
            }

            //Se instacia el mouse pointer, seguramente esto pueda ser un sprite.
            Instantiate(mousePointer, raycastHit.point, mousePointer.transform.rotation);
            //Se instacia el objeto disparado en el firepoint 
            instatiatedObject = Instantiate(ObjetoDisparado, firePointPosition.position, firePointPosition.rotation);
            //Se actualiza el inventario.
            playerInventory.gotItem = false;
            //Se activa el objeto ya que su source est� desactivado y luego se activa el script de destroy over time.
            instatiatedObject.SetActive(true);
            instatiatedObject.GetComponent<DestroyOverTime>().enabled = true;
            instatiatedObject.GetComponent<Rigidbody>().AddForce(FuerzaDisparo, ForceMode.Impulse);
            instatiatedObject.layer = 6;
            instatiatedObject.tag = "thrown";
        }

        else
        {
            //Debug.Log($"YOU DON'T HAVE A THROWABLE");
        }


    }

    private void LateUpdate()
    {


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

    private void checkInventory()
    {
        //Se comprueba en el inventario que haya algun item
        if(playerInventory.gotItem)
        {
            //Si hay item se hace que el objeto disparado sea este item que est� en el inventario. Se activa la gravedad y se hace false el trigger para que se comporte bien con la f�sica.
            ObjetoDisparado = playerInventory.itemInfo;
            ObjetoDisparado.GetComponent<Rigidbody>().useGravity = true;
            ObjetoDisparado.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {

            //Si ya tengo item en el inventario no puedo volver a agarrar un item.
            //Debug.Log("Ya ten�s un objeto");
        }
    }
}
