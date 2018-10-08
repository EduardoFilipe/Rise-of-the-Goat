using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	//move section
	Vector3 initialPosition;
	public Vector3 lastPosition;
	public float xDistance, zDistance;

	GameManager gm;

	void Start () {
		initialPosition = transform.position;
	}

	void Update() {
		Debug.DrawLine(initialPosition - new Vector3(xDistance/2,0,0),initialPosition + new Vector3(xDistance/2,0,0),Color.blue);
		Debug.DrawLine(initialPosition - new Vector3(0,0,zDistance/2),initialPosition + new Vector3(0,0,zDistance/2),Color.blue);
	}

	public void Spawn (int objectQty, GameObject obj) {
		float i = 0;
		float j = 0;
		bool alt = true;
		for (int a = 0; a < objectQty; a++) {
			FindObjectOfType<GameManager> ().enemiesOnScreen++;
			Instantiate (obj, transform.position + NewPosition (), Quaternion.identity);
			if (alt == true) {
				alt = false;
				i+= 1.5f;
			} else {
				alt = true;
				j+= 1.5f;
			}
			
		}
	}
		

	//Moving section
	public Vector3 NewPosition () {

		Vector3 newPos;
		newPos = new Vector3 (initialPosition.x-Random.Range (-xDistance / 2, xDistance / 2),initialPosition.y,initialPosition.z-Random.Range (-zDistance / 2, zDistance / 2));
		lastPosition = newPos;
		return(newPos);

	}

}
