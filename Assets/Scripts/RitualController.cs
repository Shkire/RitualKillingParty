using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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

	[SerializeField]
	private GameObject[] numbers;

	[SerializeField]
	private Sprite[] sources;

	private bool counterUnlocked;

	private int ant;


	// Use this for initialization
	void Awake ()
	{
		counterUnlocked = false;
		Debug.Log("Game controller se despierta");
		RandomizeNextPhase (0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (counterUnlocked) {
			if (timeLeft > 0) {
				timeLeft -= Time.fixedDeltaTime;
				ConfigCounter ();
			} else {
				Debug.Log ("Se acabo el tiempo");
				//guiController.FailBoard (true);
				guiController.TimeCounter (false);
				RandomizeNextPhase (ant);
			}
		}


	}

	public void RandomizeNextPhase (int num)
	{
		counterUnlocked = false;
		Debug.Log ("Randomiza y lanza juego...");
		System.Random rnd = new System.Random (Guid.NewGuid().GetHashCode());
		guiController.WinBoard (false);
		//guiController.FailBoard (false);
		guiController.TimeCounter (true);
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
		/*case 3:
			brilliantTeeth.SetActive (true);
			break;*/
		}
		if (ant!=0)
		timeLimit -= timeDecrementPerPhase;
		ant = phaseSelected;
		timeLeft = timeLimit;
		Debug.Log (ant);
	}

	private void ConfigCounter(){
		Debug.Log ("Config counter");
		int firstNum = Mathf.FloorToInt(timeLeft / 10);
		int secondNum = Mathf.FloorToInt( timeLeft / 1 - (firstNum * 10));
		int thirdNum =  Mathf.FloorToInt(timeLeft * 10 - (firstNum * 100) - (secondNum * 10));
		int fourthNum = Mathf.FloorToInt (timeLeft * 100 - (firstNum * 1000) - (secondNum * 100) - (thirdNum * 10));

		switch (firstNum) {
		case 0:
			numbers [0].GetComponent<Image> ().sprite = sources [0];
			break;
		case 1:
			numbers [0].GetComponent<Image> ().sprite = sources [1];
			break;
		case 2:
			numbers [0].GetComponent<Image> ().sprite = sources [2];
			break;
		case 3:
			numbers [0].GetComponent<Image> ().sprite = sources [3];
			break;
		case 4:
			numbers [0].GetComponent<Image> ().sprite = sources [4];
			break;
		case 5:
			numbers [0].GetComponent<Image> ().sprite = sources [5];
			break;
		case 6:
			numbers [0].GetComponent<Image> ().sprite = sources [6];
			break;
		case 7:
			numbers [0].GetComponent<Image> ().sprite = sources [7];
			break;
		case 8:
			numbers [0].GetComponent<Image> ().sprite = sources [8];
			break;
		case 9:
			numbers [0].GetComponent<Image> ().sprite = sources [9];
			break;
		}
		switch (secondNum) {
		case 0:
			numbers [1].GetComponent<Image> ().sprite = sources [0];
			break;
		case 1:
			numbers [1].GetComponent<Image> ().sprite = sources [1];
			break;
		case 2:
			numbers [1].GetComponent<Image> ().sprite = sources [2];
			break;
		case 3:
			numbers [1].GetComponent<Image> ().sprite = sources [3];
			break;
		case 4:
			numbers [1].GetComponent<Image> ().sprite = sources [4];
			break;
		case 5:
			numbers [1].GetComponent<Image> ().sprite = sources [5];
			break;
		case 6:
			numbers [1].GetComponent<Image> ().sprite = sources [6];
			break;
		case 7:
			numbers [1].GetComponent<Image> ().sprite = sources [7];
			break;
		case 8:
			numbers [1].GetComponent<Image> ().sprite = sources [8];
			break;
		case 9:
			numbers [1].GetComponent<Image> ().sprite = sources [9];
			break;
		}

		switch (thirdNum) {
		case 0:
			numbers [2].GetComponent<Image> ().sprite = sources [0];
			break;
		case 1:
			numbers [2].GetComponent<Image> ().sprite = sources [1];
			break;
		case 2:
			numbers [2].GetComponent<Image> ().sprite = sources [2];
			break;
		case 3:
			numbers [2].GetComponent<Image> ().sprite = sources [3];
			break;
		case 4:
			numbers [2].GetComponent<Image> ().sprite = sources [4];
			break;
		case 5:
			numbers [2].GetComponent<Image> ().sprite = sources [5];
			break;
		case 6:
			numbers [2].GetComponent<Image> ().sprite = sources [6];
			break;
		case 7:
			numbers [2].GetComponent<Image> ().sprite = sources [7];
			break;
		case 8:
			numbers [2].GetComponent<Image> ().sprite = sources [8];
			break;
		case 9:
			numbers [2].GetComponent<Image> ().sprite = sources [9];
			break;
		}

		switch (fourthNum) {
		case 0:
			numbers [3].GetComponent<Image> ().sprite = sources [0];
			break;
		case 1:
			numbers [3].GetComponent<Image> ().sprite = sources [1];
			break;
		case 2:
			numbers [3].GetComponent<Image> ().sprite = sources [2];
			break;
		case 3:
			numbers [3].GetComponent<Image> ().sprite = sources [3];
			break;
		case 4:
			numbers [3].GetComponent<Image> ().sprite = sources [4];
			break;
		case 5:
			numbers [3].GetComponent<Image> ().sprite = sources [5];
			break;
		case 6:
			numbers [3].GetComponent<Image> ().sprite = sources [6];
			break;
		case 7:
			numbers [3].GetComponent<Image> ().sprite = sources [7];
			break;
		case 8:
			numbers [3].GetComponent<Image> ().sprite = sources [8];
			break;
		case 9:
			numbers [3].GetComponent<Image> ().sprite = sources [9];
			break;
		}
			
	}

	public void UnlockCounter(){
		counterUnlocked = true;
	}
}
