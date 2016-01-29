using UnityEngine;
using System.Collections;

public class VoodooGameController : MonoBehaviour {


	[SerializeField]
	private bool[] targetsIsClicked;

	[SerializeField]
	private GameObject[] targetsPoints;

	[SerializeField]
	private GameObject needlePattern;

	[SerializeField]
	private GameObject paasermeexulo;

	private System.Random rand;
	private bool ok = false;

	// Use this for initialization
	void Start () {
	rand = new System.Random (2141244);





	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!ok) {
			if (targetsIsClicked [0] && targetsIsClicked [1] && targetsIsClicked [2] && targetsIsClicked [3]) {

				Debug.Log ("Cambio de Scene");
				ok = true;

			}
		}	


		if (Input.GetMouseButtonDown(0)) {	
			RaycastHit2D[] hits = new RaycastHit2D[2];
			int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hits);
			if (num>0)
				foreach (RaycastHit2D hit in hits) {
					
					if (hit.collider.gameObject.tag.Equals ("VoodooPoint")) {
						

						for (int i = 0; i < (targetsPoints.Length ); i++) {
							
							if ((hit.collider.gameObject.Equals(targetsPoints [i])) && (!targetsIsClicked[i])) {

								GameObject needle = (GameObject) Instantiate(needlePattern,targetsPoints [i].transform.position,needlePattern.transform.rotation);

								needle.transform.localScale = new Vector3(needle.transform.localScale.x, rand.Next (1,5), needle.transform.localScale.z);
								needle.transform.Rotate(new Vector3(0, 0, rand.Next (0, 360)));

								targetsIsClicked [i] = true;
								break;
							}
				
								
						}
						break;
					}

				}
		}

	}
}
