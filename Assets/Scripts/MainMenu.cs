using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private RitualController gameController;

	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.GetKeyDown (KeyCode.Return)) {

			gameController.gameObject.SetActive (true);
			this.gameObject.SetActive (false);

		}

	}
}
