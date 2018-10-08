using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//blood stuff
	public ParticleSystem[] corpseExplosion;


	public float speed, jumpSpeed, gravity, force, timer, timerAtk, spdAtk;
	private Vector3 moveDirection = Vector3.zero;
	public bool atk;
	CharacterController controller;
	void Start (){
		controller = GetComponent<CharacterController>();
		spdAtk = speed;
	}

	void FixedUpdate () {
		Movement ();
		Atack ();
	}

	void Movement () {
		
			if (controller.isGrounded) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				if (Input.GetButton ("Jump"))
					moveDirection.y = jumpSpeed;

			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);

	}

	void Atack () {
		if (timer > 0.3f) {
			if (Input.GetKey(KeyCode.Mouse0) && !atk) {
				speed = 1;
				force += (Time.deltaTime * 30);
				if (force > 120){
					force = 120;
				}
			}
			timerAtk += Time.deltaTime;
			if (Input.GetKeyUp (KeyCode.Mouse0) && !atk) {
				atk = true;
				timerAtk = 0;
				GetComponent<CharacterController> ().enabled = false;
				GetComponent<Rigidbody> ().isKinematic = false;
				GetComponent<Rigidbody> ().AddForce (transform.forward * force, ForceMode.Impulse);
			}
		} else {
			timer += Time.deltaTime;
			timerAtk = 0;
			GetComponent<CharacterController> ().enabled = true;
			GetComponent<Rigidbody> ().isKinematic = true;
		}
		if (timerAtk >= 0.3f && atk) {
			force = 20;
			speed = spdAtk;
			atk = false;
			timer = 0;
		}
	}

	void OnCollisionEnter (Collision coll) {
		if (atk == true) {
			gameObject.GetComponent<CameraShake> ().shakeDuration += 1;
			if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Padre") {
				coll.gameObject.GetComponent<EnemyHP> ().GetHit ();

			}
		}
	}
	void OnCollisionStay (Collision coll) {
		if (atk == true) {
			if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Padre") {
				coll.gameObject.GetComponent<EnemyHP> ().GetHit ();

			}
		}
	}

	public void SplatterBlood(){
		foreach (ParticleSystem ps in corpseExplosion) {
			ps.Play ();
		}
	}

}
