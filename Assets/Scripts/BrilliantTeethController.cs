using UnityEngine;
using System.Collections;
using System;

public class BrilliantTeethController : MonoBehaviour {


	[SerializeField]
	private bool picked  = false;

	[SerializeField]
	private GameObject instantiatedFine;

	[SerializeField]
	private GameObject[] dientes;

	[SerializeField]
	private GameObject[] dientes2;

	[SerializeField]
	private int max = 21;

	[SerializeField]
	private int min = 2;

	private System.Random rand;

	// Use this for initialization
	void OnEnable () {

		rand = new System.Random (Guid.NewGuid ().GetHashCode ());

		int randomnumber = rand.Next (min, max);


		dientes2 = new GameObject[randomnumber];

		for (int r = 0; r < randomnumber; r++) {

			int randomtarget;

			do{

				randomtarget = rand.Next(0, (dientes.Length -1));


			}while(dientes[randomtarget].activeSelf);

			dientes2 [r] = dientes [randomtarget];
			dientes2 [r].SetActive (true);

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		/*void OnTriggerExit(BoxCollider2D a){

		}*/


		if (Input.GetMouseButtonDown (0)) {


			RaycastHit2D[] hit = new RaycastHit2D[1];
			int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hit);

			if (hit [0].collider.gameObject.tag.Equals ("Fine")) {
				
				picked = true;

			}
		}

			if (Input.GetMouseButton (0) && picked) {

				instantiatedFine.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
				
				//if(
				

			
			} else if (Input.GetMouseButtonUp (0) || !picked) {

				instantiatedFine.transform.position = new Vector3 (instantiatedFine.transform.position.x, instantiatedFine.transform.position.y, 0);

			}


			}



}
