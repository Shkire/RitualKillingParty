using UnityEngine;
using System.Collections;
using System;

public class VoodooGameController : MonoBehaviour {

	[SerializeField]
	private Animator dollAnimator;

	[SerializeField]
	private ManageAudioClips dollAudio;

	[SerializeField]
	private bool[] targetsIsClicked;

	[SerializeField]
	private GameObject[] targetsPoints;

	[SerializeField]
	private GameObject[] activeTargets;

	[SerializeField]
	private GameObject needlePattern;

	[SerializeField]
	private GameObject target;

	[SerializeField]
	private int max = 10;

	[SerializeField]
	private int min = 2;

	[SerializeField]
	private GuiController guiController;

	[SerializeField]
	private RitualController gameController;

	private bool completado;

	private float timeToNextPhase = 3;

	private float timeLeftToNextPhase = 3;



	private System.Random rand;

	// Use this for initialization
	void OnEnable() {
		Debug.Log ("AWAKEEEE VOODOO");
		completado = false;
		timeLeftToNextPhase = timeToNextPhase;


		rand = new System.Random (Guid.NewGuid().GetHashCode());

		int randomnumber = rand.Next(min,max);


		targetsIsClicked = new bool[randomnumber];
		activeTargets = new GameObject[randomnumber];

		for (int r = 0; r < randomnumber; r++) {
			int randomtarget;

			do{

				randomtarget = rand.Next(0, (targetsPoints.Length -1));


			}while(targetsPoints[randomtarget].activeSelf);

			activeTargets [r] = targetsPoints [randomtarget];
			activeTargets [r].SetActive (true);

		}

		Debug.Log("Desbloqueo Contador");
		gameController.UnlockCounter ();


	}

	// Update is called once per frame
	void FixedUpdate () {

		if (completado) {

			timeLeftToNextPhase -= Time.fixedDeltaTime;
			if (timeLeftToNextPhase <= 0) {
				GameObject[] needles = GameObject.FindGameObjectsWithTag ("Needle");
				for (int i = 0; i < needles.Length; i++) {
					Destroy(needles [i]);
				}
				gameController.RandomizeNextPhase (1);
			}

		} else {

			//if (!ok) {
			//	if (targetsIsClicked [0] && targetsIsClicked [1] && targetsIsClicked [2] && targetsIsClicked [3]) {

			//		Debug.Log ("Cambio de Scene");
			//		ok = true;

			//	}
			//}	
			if (IsCompleted ()) {
				gameController.LockCounter ();
				guiController.WinBoard (true);
				completado = true;
				timeLeftToNextPhase = timeToNextPhase;

			}

			if (Input.GetMouseButtonDown (0)) {	

				RaycastHit2D[] hits = new RaycastHit2D[4];
				int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hits);

				if (num > 0)
					foreach (RaycastHit2D hit in hits) {

						if(hit.collider){

							if (hit.collider.gameObject.tag.Equals ("VoodooPoint")) {

								int i;
								for (i = 0; i < (activeTargets.Length); i++) {

									if ((hit.collider.gameObject.Equals (activeTargets [i])) && (!targetsIsClicked [i])) {

										GameObject needle = (GameObject)Instantiate (needlePattern, activeTargets [i].transform.position, needlePattern.transform.rotation);

										dollAudio.Play (1);
										dollAnimator.SetTrigger ("happy");

										needle.transform.localScale = new Vector3 (needle.transform.localScale.x, ((float)rand.NextDouble () * 1 + 0.7f) * needle.transform.localScale.y, needle.transform.localScale.z);
										needle.transform.Rotate (new Vector3 (0, 0, rand.Next (0, 360)));

										targetsIsClicked [i] = true;
										break;
									}




								}

								if (i <= activeTargets.Length) {
									break;
								}

							}

							if (hit.collider.gameObject.tag.Equals ("VoodooHurt")) {

								dollAudio.Play (0);
								dollAnimator.SetTrigger ("sad");

								break;
							}




						}



					}
			}
		}

	}

	private bool IsCompleted(){
		bool checking = true;
		foreach (bool checkedBool in targetsIsClicked)
			if (!checkedBool) {
				checking = false;
				break;
			}

		return checking;
	}

	public void ResetLevel(){

		foreach (GameObject go in targetsPoints) {

			GameObject[] needles = GameObject.FindGameObjectsWithTag ("Needle");
			for (int i = 0; i < needles.Length; i++) {
				Destroy(needles [i]);
			}
			go.SetActive (false);
			completado = false;


		}

	}
}