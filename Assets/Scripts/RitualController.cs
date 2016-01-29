using UnityEngine;
using System.Collections;

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



	// Use this for initialization
	void Awake ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void RandomizeNextPhase (int num)
	{

		System.Random rnd = new System.Random (123456);
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
