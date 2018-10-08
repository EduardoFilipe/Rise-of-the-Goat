using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadreImunidade : MonoBehaviour {
	GameObject padre;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (padre != null) {
			if (Vector3.Distance (transform.position, padre.transform.position) < 4.5f) {
				GetComponent<EnemyHP> ().imune = true;
			} else {
				GetComponent<EnemyHP> ().imune = false;
			}
		} else {
			GetComponent<EnemyHP> ().imune = false;
		}
	}

	void OnTriggerStay (Collider coll){
		if (coll.tag == "Padre") {
			padre = coll.gameObject;
		}
	}
}
