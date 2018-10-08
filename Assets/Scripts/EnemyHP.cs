using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

	public ParticleSystem bloodParticle;

	AudioSource audioSource;
	public string deathSound, hit;
	public float timerHitSound;
	public int HP;
	public GameObject body;
	public Rigidbody rb;
	public Animator anim;
	public bool dead, imune;
	void Awake () {
		audioSource = GetComponent<AudioSource> ();
		dead = imune = false;
		rb = gameObject.GetComponent<Rigidbody> ();
		anim = body.GetComponent<Animator> ();
	}
		

	public void GetHit () {
		if (!imune) {
			FindObjectOfType<CameraShake> ().shakeDuration += 1;
			if (HP - 1 <= 0) {
				Die ();
				HP = 0;

			} else
				HP--;
		}
	}

	void Update() {
		timerHitSound += Time.deltaTime;
		if (HP <= 0)
			Destroy (this.gameObject);
	}
	void Die() {
		if (dead == false) {
			dead = true;
			if (deathSound != null)
				FindObjectOfType<AudioManager> ().Play (deathSound, GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>());
		
			FindObjectOfType<GameManager> ().enemiesOnScreen--;
			//print ("enemy died");
			Instantiate(bloodParticle,transform.position,Quaternion.identity);
			FindObjectOfType<PlayerController>().SplatterBlood();
			FindObjectOfType<ComboManager> ().AddToCombo ();
			Destroy (this.gameObject);

		}
	}

	void OnTriggerStay() {
		if (rb.velocity.magnitude > 0.25f) {
			anim.SetBool ("attacking", false);

		} else {
			anim.SetBool ("attacking", true);
			if (timerHitSound > 0.7f) {
				FindObjectOfType<AudioManager> ().Play (hit, GetComponent<AudioSource>());
				timerHitSound = 0;
			}
		}
	}

}
