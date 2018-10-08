using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	Rigidbody rb;
	public int maxvelocity;
	bool alive;
	float timer;
	Vector3	 temp;
	// Use this for initialization
	void Start () {
		alive = true;
		rb = this.GetComponent<Rigidbody> ();
	}
		
	void LateUpdate () {
		
		timer += Time.deltaTime;
		if (Input.GetKey (KeyCode.F) && timer >= 5) {
				temp = rb.velocity * 2;

				rb.velocity = temp;
				timer = 0;
		
		} else {
			if (Input.GetKey (KeyCode.LeftControl)) {
				rb.velocity = new Vector3 (0, 0, 0);
			} else if (Input.GetKey (KeyCode.W)) {
	
	
				rb.AddForce (new Vector3 (25000, 0, 0));
	
			} else if (Input.GetKey (KeyCode.S)) {
	
	
	
				rb.AddForce (new Vector3 (-25000, 0, 0));
	
	
			} else if (Input.GetKey (KeyCode.A)) {
	
				rb.AddForce (new Vector3 (0, 0, 25000));
	
			} else if (Input.GetKey (KeyCode.D)) {
	
				rb.AddForce (new Vector3 (0, 0, -25000));
	
			} 

		}
	}
		



}
