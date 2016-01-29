using UnityEngine;
using System.Collections;

public class BloodEagleController: MonoBehaviour
{

	[SerializeField]
	private GameObject[] firstCutPattern;

	[SerializeField]
	private GameObject[] secondCutPattern;

	[SerializeField]
	private bool[] firstCutIsClicked;

	[SerializeField]
	private bool[] secondCutIsClicked;

	[SerializeField]
	private GameObject cutterPattern;

	[SerializeField]
	private GameObject instantiatedCutter;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (Input.GetMouseButtonDown (0)) {	
			instantiatedCutter = (GameObject)Instantiate (cutterPattern, Camera.main.ScreenToWorldPoint (Input.mousePosition), cutterPattern.transform.rotation);
		}

		if (Input.GetMouseButtonUp (0)) {
			Destroy (instantiatedCutter);
			if (!IsCompleted (1))
				for(int i=0;i<firstCutIsClicked.Length;i++){
					firstCutIsClicked[i] = false;
				}
			if (!IsCompleted (2))
				for(int i=0;i<secondCutIsClicked.Length;i++) {
					secondCutIsClicked [i] = false;
				}
		}
		if (Input.GetMouseButton (0) && instantiatedCutter) {
			instantiatedCutter.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D[] hits = new RaycastHit2D[2];
			int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hits);
			if (num > 0)
				foreach (RaycastHit2D hit in hits) {
					if (hit.collider.gameObject.tag.Equals ("BloodEaglePoint")) {
						for (int i = 0; i < firstCutPattern.Length; i++) {
							if (hit.collider.gameObject.Equals (firstCutPattern [i]))
								firstCutIsClicked [i] = true;
							break;
						}
							
						for (int i = 0; i < secondCutPattern.Length; i++) {
							if (hit.collider.gameObject.Equals (secondCutPattern [i]))
								secondCutIsClicked [i] = true;
							break;
						}
					}
				}
		}
	}

	private bool IsCompleted(int n){
		bool isChecked = true;
		if (n == 1) {
			foreach (bool check in firstCutIsClicked) {
				if (!check) {
					isChecked = false;
					break;
				}
			}
		}

		if (n == 2) {
			foreach (bool check in secondCutIsClicked) {
				if (!check) {
					isChecked = false;
					break;
				}
			}
		}

		return isChecked;
	}

}
