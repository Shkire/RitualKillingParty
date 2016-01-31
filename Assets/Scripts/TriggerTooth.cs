using System;
using UnityEngine;

public class TriggerTooth : MonoBehaviour {

	[SerializeField]
	private BrilliantTeethController brilliantTeethController;

	void OnTriggerExit2D (Collider2D coll){
		
			if (coll.gameObject.tag.Equals ("tooth")) {
			
				for(int i = 0; i< brilliantTeethController.dientes2.Length; i++){

			
					if(brilliantTeethController.dientes2[i].Equals(coll.gameObject)){
					
							brilliantTeethController.dientes2[i].SetActive(false);
				}

			}

			}
		}
}

