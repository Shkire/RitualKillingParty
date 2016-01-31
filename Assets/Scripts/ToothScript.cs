using UnityEngine;
using System.Collections;

public class ToothScript : MonoBehaviour {

	[SerializeField]
	private ToothScript otraMitad;

	public ArrayList dientes;

	void Awake (){
	
		dientes = new ArrayList ();

	}




	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.gameObject.tag.Equals ("tooth")) {

			Debug.Log (coll.gameObject);
			//otraMitad.dientes.Contains(coll.gameObject)

			if(true){
				

				if (coll.gameObject.transform.rotation.z == -1.0) {
					
					coll.gameObject.transform.position = coll.gameObject.transform.position + new Vector3 (0, 0.02f, 0);
				} else {
					coll.gameObject.transform.position = coll.gameObject.transform.position + new Vector3 (0, -0.02f, 0);
				}

				otraMitad.dientes.Remove (gameObject);

			}
				
			dientes.Add (gameObject);

	}
}
}