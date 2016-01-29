using UnityEngine;
using System.Collections;

public class VoodooGameController : MonoBehaviour {


	[SerializeField]
	private bool[] targetsIsClicked;

	[SerializeField]
	private GameObject[] targetsPoints;

	[SerializeField]
	private GameObject needlePattern;

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
						

						for (int i = 0; i < (targetsPoints.Length ); i++) {
							
							if (hit.collider.gameObject.Equals(targetsPoints [i])) {

								Instantiate(needlePattern);

								targetsIsClicked [i] = true;
								break;
							}


								//hit.collider.gameObject.transform.Rotate(new Vector3(0,0,45));
								
						}
						break;
					}

				}
		}

	}
}
