using UnityEngine;
using System.Collections;

public class VoodooGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0)) {	
			RaycastHit2D[] hits = new RaycastHit2D[2];
			int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hits);
			if (num>0)
				foreach (RaycastHit2D hit in hits) {
					if (hit.collider.gameObject.tag.Equals ("VoodooPoint")) {
						Destroy (hit.collider.gameObject);
						break;
					}
				}
		}

	}
}
