using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private RitualController gameController;

	[SerializeField]
	private GameObject pressEnter;

	void OnEnable(){

		pressEnter.SetActive (true);

	}

	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.GetKeyDown (KeyCode.Return)) {

			gameController.gameObject.SetActive (true);
			this.gameObject.SetActive (false);

		}

	}
}
