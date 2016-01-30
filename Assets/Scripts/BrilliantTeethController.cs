using UnityEngine;
using System.Collections;

public class BrilliantTeethController : MonoBehaviour {


	[SerializeField]
	private bool picked  = false;

	[SerializeField]
	private GameObject instantiatedFine;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {




		if (Input.GetMouseButtonDown (0)) {


			RaycastHit2D[] hit = new RaycastHit2D[1];
			int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hit);

			if (hit [0].collider.gameObject.tag.Equals ("Fine")) {
				
				picked = true;

			}
		}

			if (Input.GetMouseButton (0) && picked) {

				instantiatedFine.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
				

			
			} else if (Input.GetMouseButtonUp (0) || !picked) {

				instantiatedFine.transform.position = new Vector3 (instantiatedFine.transform.position.x, instantiatedFine.transform.position.y, 0);

			}


			}



}
