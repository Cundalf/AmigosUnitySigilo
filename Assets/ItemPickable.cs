using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour
{
    [SerializeField] private BoxCollider colliderArrojable;
    [SerializeField] public Inventory playerInventory;
    [SerializeField] public GameObject itemInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInventory.gotItem)
        {
            //Si el collider es Player y en el inventario el booleano es false se procede a agarrar el item y hacerlo invisible.
            playerInventory.gotItem = true;
            playerInventory.itemInfo = itemInfo;

            itemInfo.SetActive(false);
            
        }

    }
}
