using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	bool alive;
	public Rigidbody rb;
	public Transform target;
	public float speed;


	void Start () {
		speed = Random.Range (100, 170) + FindObjectOfType<GameManager>().wave * 5;
		alive = true;
		target = GameObject.FindGameObjectWithTag ("Objective").transform;
		rb = this.GetComponent<Rigidbody> ();
		StartCoroutine ("ChangeDirection");
		transform.LookAt (target);
		transform.Rotate (0, -90, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.magnitude < 1) {
			rb.AddRelativeForce(new Vector3 (speed,0,0));
		}
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Objective").transform;
		}
	}
		

	IEnumerator ChangeDirection () {
		while (alive == true){


			transform.LookAt (target);
			transform.Rotate (0, -90, 0);
			yield return new WaitForSeconds (2);	
		}
		yield break;
	}

	//voi
}
