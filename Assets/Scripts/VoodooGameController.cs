﻿using UnityEngine;
using System.Collections;
using System;

public class VoodooGameController : MonoBehaviour {


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
	void Awake () {


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



		//for (int p = 0; p < activeTargets.Length; p++) {

		//	activeTargets [p].SetActive (true);

//		}


		//.setActive para activar

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (completado) {

			timeLeftToNextPhase -= Time.fixedDeltaTime;
			if (timeLeftToNextPhase <= 0)
				gameController.RandomizeNextPhase (1);
			
		} else {

			//if (!ok) {
			//	if (targetsIsClicked [0] && targetsIsClicked [1] && targetsIsClicked [2] && targetsIsClicked [3]) {

			//		Debug.Log ("Cambio de Scene");
			//		ok = true;

			//	}
			//}	
			if (IsCompleted ()) {
				guiController.WinBoard (true);
				completado = true;
				timeLeftToNextPhase = timeToNextPhase;

			}

			if (Input.GetMouseButtonDown (0)) {	
				RaycastHit2D[] hits = new RaycastHit2D[2];
				int num = Physics2D.GetRayIntersectionNonAlloc (Camera.main.ScreenPointToRay (Input.mousePosition), hits);
				if (num > 0)
					foreach (RaycastHit2D hit in hits) {
					
						if (hit.collider.gameObject.tag.Equals ("VoodooPoint")) {
						

							for (int i = 0; i < (activeTargets.Length); i++) {
							
								if ((hit.collider.gameObject.Equals (activeTargets [i])) && (!targetsIsClicked [i])) {

									GameObject needle = (GameObject)Instantiate (needlePattern, activeTargets [i].transform.position, needlePattern.transform.rotation);

									needle.transform.localScale = new Vector3 (needle.transform.localScale.x, ((float)rand.NextDouble () * 1 + 0.7f) * needle.transform.localScale.y, needle.transform.localScale.z);
									needle.transform.Rotate (new Vector3 (0, 0, rand.Next (0, 360)));

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

	private bool IsCompleted(){
		bool checking = true;
		foreach (bool checkedBool in targetsIsClicked)
			if (!checkedBool) {
				checking = false;
				break;
			}
				
		return checking;
	}
}
