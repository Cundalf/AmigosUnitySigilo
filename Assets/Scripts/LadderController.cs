using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


	public class LadderController : MonoBehaviour

	{
		/*ACLARACIONES PARA LAS HITBOXES"
		 * En las estructuras que uno quiera escalar debera implementarse un Box Collider con is Trigger activado que debera sobresalir de la hitbox normal del objeto para que sea lo primero a lo que el player impacte.
		 * para el caso de estructuras como cajas es recomendable que la hitbox sea un rectagulo que se encuentre en la parte superior de la cara que vas a subir. aproximadamente 1/4 del largo de la cara.
		 * para superficies largas como escaleras la hitbox debera estar alejada del piso y debe estar a la misma altura que la hitbox normal de la escalera.
		*/
		public Transform chController;
		bool inside = false;
		public float speedUpDown;  //Velocidad ideal alrededor de 30.0
		public PlayerController tpc; //TU SCRIPT DE MOVIMIENTO.
		public bool ladderInSight = false;
		public NavMeshAgent Player;
		public Rigidbody playerRB;
		public BoxCollider playerBC;

		void Start()
		{
			tpc = GetComponent<PlayerController>();
			inside = false;
		}
		//Si collisiona con un collider con el tag "Ladder" de desactiva el scrip del control de movimiento que se le pasa por parametro.
		void OnTriggerEnter(Collider col)
		{

		// Se modifica este código. Aquí solo queda la validación de si el player está o no efectivamente en un collider de una escalera

			
			if (col.gameObject.tag == "Ladder")
			{
				
				inside = !inside;
			}
		
			

		}
		//Vuelve a activar el sistema de movimiento. 
		void OnTriggerExit(Collider col)
		{
			if (col.gameObject.tag == "Ladder")
			{
				
				inside = !inside;
			Debug.Log("Saliste de la escalera");
			}
		}

		void Update()
		{



			// si te encuentras adentro de la hitbox del objeto a escalar los input w y s te moveran hacia arriba y abajo respectivamente. El movimiento lateral no existe.
			if (inside == true)
			{
			
			playerBC.isTrigger = false;
			Player.enabled = false;
			//si presiono la tecla que habilita el climb funcionará solo estando dentro del rango del collider.
				if(Input.GetKeyDown(KeyCode.B))
	            {
					ladderInSight = true;
					tpc.enabled = false;
			}
				if (Input.GetKey("w") && ladderInSight)
				{
					chController.transform.position += Vector3.up / speedUpDown ;

				}

				if (Input.GetKey("s") && ladderInSight)
				{
					chController.transform.position += Vector3.down / speedUpDown;
				}
			}

			else
			{
			tpc.enabled = true;
			ladderInSight = false;
			}

		}
	}
