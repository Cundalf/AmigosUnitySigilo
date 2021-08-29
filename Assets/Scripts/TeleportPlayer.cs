using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportDestiny;
    public TeleportPlayer destinyTP;
    public GameObject thePlayer;
    public bool inState = true;

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
        if (other.CompareTag("Player") && inState)
        {
            destinyTP.inState = true;
            inState = false;
            thePlayer.transform.position = teleportDestiny.transform.position;
            
        }
    }
}
