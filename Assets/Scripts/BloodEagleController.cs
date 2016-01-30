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

	[SerializeField]
	private GuiController guiController;

	private float timeToNextPhase = 3;

	private float timeLeftToNextPhase = 3;

	private bool completed;

	[SerializeField]
	private RitualController gameController;

	// Use this for initialization
	void OnEnable()
	{
		gameController.UnlockCounter ();	
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!completed) {
			if (Input.GetMouseButtonDown (0)) {	
				instantiatedCutter = (GameObject)Instantiate (cutterPattern, new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0), cutterPattern.transform.rotation);
			}

			if (Input.GetMouseButtonUp (0)) {
				ResetIncomplete ();
			}
			if (Input.GetMouseButton (0) && instantiatedCutter) {
				foreach (GameObject axe in GameObject.FindGameObjectsWithTag ("Axe")) {
					if (!axe.Equals (instantiatedCutter))
						Destroy (axe);
				}
				instantiatedCutter.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
				RaycastHit2D[] hits = new RaycastHit2D[3];
				int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hits);
				if (num > 0)
					foreach (RaycastHit2D hit in hits) {
						if (hit.collider != null)
						if (hit.collider.gameObject.tag.Equals ("BackPoint")) {
							for (int i = 0; i < firstCutPattern.Length; i++) {
								if (hit.collider.gameObject.Equals (firstCutPattern [i])) {
									firstCutIsClicked [i] = true;
									firstCutPattern [i].GetComponentInParent<SpriteRenderer> ().enabled = false;
									break;
								}
							}
								
							for (int i = 0; i < secondCutPattern.Length; i++) {
								if (hit.collider.gameObject.Equals (secondCutPattern [i])) {
									secondCutIsClicked [i] = true;
									secondCutPattern [i].GetComponentInParent<SpriteRenderer> ().enabled = false;
									break;
								}
							}
						}
						if (hit.collider != null)
						if (hit.collider.gameObject.tag.Equals ("BackHurt")) {
							ResetIncomplete ();
							break;
						}
					}
			}
		

			if (IsCompleted (1) && IsCompleted (2)) {
				Destroy (instantiatedCutter);
				WinEffect ();
				timeLeftToNextPhase = timeToNextPhase;
			}
		} else {
			timeLeftToNextPhase -= Time.fixedDeltaTime;
			if (timeLeftToNextPhase <= 0)
				gameController.RandomizeNextPhase (2);
		}
	}

	private bool IsCompleted (int n)
	{
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

	private void ResetIncomplete(){
		Destroy (instantiatedCutter);
		if (!IsCompleted (1))
			for (int i = 0; i < firstCutIsClicked.Length; i++) {
				firstCutIsClicked [i] = false;
				firstCutPattern [i].GetComponentInParent<SpriteRenderer> ().enabled = true;
			}
		if (!IsCompleted (2))
			for (int i = 0; i < secondCutIsClicked.Length; i++) {
				secondCutIsClicked [i] = false;
				secondCutPattern [i].GetComponentInParent<SpriteRenderer> ().enabled = true;
			}
	}

	private void WinEffect(){
	
		guiController.WinBoard (true);
		completed = true;

	}
}
