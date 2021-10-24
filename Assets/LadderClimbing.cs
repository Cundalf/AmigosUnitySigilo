using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private NewLadderController player;
    public bool playerPresent;
    public Transform startPos;
    public BoxCollider thisBoxColl;
   
    // Start is called before the first frame update
    void Start()
    {
        thisBoxColl = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresent && Input.GetKeyDown(KeyCode.B))
        {
            player.characterController.enabled = false;
            


            Debug.Log("Player on trigger ladder");
            player.OnLadder(startPos.position, this);
            playerPresent = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            player = other.GetComponent<NewLadderController>();
            if(player != null && !player.onLadder)
            {
                playerPresent = true;
            }
        }
    }
}
