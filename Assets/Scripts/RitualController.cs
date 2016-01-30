using UnityEngine;
using System.Collections;
using System;

public class RitualController : MonoBehaviour
{

	[SerializeField]
	private GameObject voodooGame;

	[SerializeField]
	private GameObject bloodEagle;

	[SerializeField]
	private GameObject brilliantTeeth;

	private int lifes = 3;

	[SerializeField]
	private float timeLimit;

	[SerializeField]
	private float timeLeft;

	[SerializeField]
	private float timeDecrementPerPhase;

	[SerializeField]
	private GuiController guiController;



	// Use this for initialization
	void Awake ()
	{
		timeLeft = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		timeLeft -= Time.fixedDeltaTime;
		Debug.Log (timeLeft);


	}

	public void RandomizeNextPhase (int num)
	{

		System.Random rnd = new System.Random (Guid.NewGuid().GetHashCode());
		guiController.WinBoard (false);
		voodooGame.SetActive (false);
		bloodEagle.SetActive (false);
		brilliantTeeth.SetActive (false);
		int phaseSelected;

		do {
			phaseSelected = rnd.Next (1, 3);
		} while (phaseSelected == num);

		switch (phaseSelected) {
		case 1:
			voodooGame.SetActive (true);
			break;
		case 2:
			bloodEagle.SetActive (true);
			break;
		case 3:
			brilliantTeeth.SetActive (true);
			break;
		}

	}
}
