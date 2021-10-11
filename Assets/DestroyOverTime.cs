using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private GameObject esteObjeto;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(esteObjeto);
    }
}
