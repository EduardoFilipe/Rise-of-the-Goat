using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church : MonoBehaviour {
	void OnTriggerStay (Collider coll) {
		if (coll.tag == "Enemy") {
			FindObjectOfType<GameManager> ().GetDamaged ();
		}
	}
}
