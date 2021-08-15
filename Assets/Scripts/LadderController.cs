using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LadderController : MonoBehaviour

{

	public Transform chController;
	bool inside = false;
	public float speedUpDown = 0.3f;
	public PlayerController tpc;

	void Start()
	{
		tpc = GetComponent<PlayerController>();
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			tpc.enabled = false;
			inside = !inside;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			tpc.enabled = true;
			inside = !inside;
		}
	}

	void Update()
	{
		if (inside == true)
		{
			if (Input.GetKey("w"))
			{
				chController.transform.position += Vector3.up / speedUpDown;

			}
		
			if (Input.GetKey("s"))
			{
				chController.transform.position += Vector3.down / speedUpDown;
			}
		}
	
	}

}