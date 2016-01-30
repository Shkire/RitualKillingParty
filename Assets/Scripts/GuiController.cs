using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	[SerializeField]
	private GameObject winBoard;

	[SerializeField]
	private GameObject failBoard;

	[SerializeField]
	private GameObject timeCounter;

	public void WinBoard(bool state){
		winBoard.SetActive (state);
	}

	public void FailBoard(bool state){
		failBoard.SetActive (state);
	}

	public void TimeCounter(bool state){
		timeCounter.SetActive (state);
	}

}
