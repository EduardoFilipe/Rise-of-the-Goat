using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakeable : FixOnGround {

	public string breakSound;
	public int MaxHp;
	public int Hp;
	public GameObject respawnable;
	List<Rigidbody> children;
	Quaternion[] rotations;
	Vector3[] positions;
	GameObject [] gObjects;
	bool broken;
	void Awake () {
		Align (transform);
		broken = false;
		MaxHp = MaxHp * 100;
		Hp = MaxHp ;
		children = new List<Rigidbody>();
		for (int i = 0; i < respawnable.transform.childCount;  i++) 
			if(respawnable.transform.GetChild(i).GetComponent<Rigidbody>() != null)
				children.Add(respawnable.transform.GetChild(i).GetComponent<Rigidbody>());
		
		rotations = new Quaternion[respawnable.transform.childCount];
		positions = new Vector3[respawnable.transform.childCount];
		gObjects = new GameObject[respawnable.transform.childCount];
		for (int i = 0; i < positions.GetLength (0); i++) {
			rotations [i] = respawnable.transform.GetChild (i).transform.rotation;
			positions [i] = respawnable.transform.GetChild (i).transform.position;
			gObjects [i] = respawnable.transform.GetChild (i).transform.gameObject;
		}


			

	}


	public void Fix () { 
		respawnable.transform.DetachChildren ();
		for (int i = 0; i < positions.GetLength (0); i++) {
			gObjects [i].transform.SetPositionAndRotation (positions [i], rotations[i]);
			children [i].isKinematic = true;
			gObjects [i].transform.SetParent (respawnable.transform);
			gObjects [i].layer = 0;
		}
		Hp = MaxHp;
		broken = false;
	}

	void OnTriggerStay(Collider coll) {
		
		if(coll.tag == "Player" && coll.GetComponent<PlayerController>().atk == true) {
			if (Hp > 0) {
				Hp-= 1*25;
			} else {
				if (broken == false) {
					FindObjectOfType<CameraShake> ().shakeDuration += 1;
					if (breakSound != null)
						FindObjectOfType<AudioManager> ().Play (breakSound, coll.GetComponent<AudioSource>());
					//transform.DetachChildren ();
					broken = true;
	
					for (int j = 0; j < children.Count; j++) {
						children [j].isKinematic = false;
					}
					broken = true;
				}

			}
		} else if(coll.tag == "Enemy") {
			if (Hp > 0) {
				Hp--;
			} else {
				if (broken == false) {
					if (breakSound != null)
						FindObjectOfType<AudioManager> ().Play (breakSound,coll.GetComponent<AudioSource>());
					//transform.DetachChildren ();
					if (broken == false) {
						StartCoroutine ("BoostEnemy");
						coll.transform.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (25, 0, 0));
					}
					for (int j = 0; j < children.Count; j++) {
						children [j].isKinematic = false;
					}
					broken = true;
				}
			}
		}
	}

	IEnumerator BoostEnemy () {
		yield return new WaitForSeconds (0.3f);
		broken = true;
		yield return new WaitForSeconds (2);
		for (int j = 0; j < children.Count; j++) {
			gObjects [j].layer = 9;
		}
	}
}
