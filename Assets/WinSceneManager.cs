using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour {

	public Text finalPoints,despertar1,despertar2,despertar3;
	public CameraShake cs;
	public Image black;
	public Image white;
	public Light directional;
	public GameObject hand;
	public ParticleSystem particles;




	Vector3 initialHandPos;
	// Use this for initialization
	void Start () {
		finalPoints.color += new Color (0, 0, 0, -1);
		despertar1.color += new Color (0, 0, 0, -1);
		despertar2.color += new Color (0, 0, 0, -1);
		despertar3.color += new Color (0, 0, 0, -1);
		initialHandPos = hand.transform.position;
		StartCoroutine (Scene());
	}

	// Update is called once per frame
	IEnumerator Scene () {
		yield return new WaitForSeconds (1);

		while (finalPoints.color.a <1) {
			finalPoints.color += new Color (0, 0, 0, 0.05f);
			yield return null;
		}

		yield return new WaitForSeconds (5);//6

		while (finalPoints.color.a >0) {
			finalPoints.color += new Color (0, 0, 0, -0.05f);
			yield return null;
		}
	
		while (white.color.r > 0) {
			white.color += new Color (-0.01f, -0.01f, -0.01f, 0);
			yield return null;
		}

		while (despertar1.color.a <1) {
			despertar1.color += new Color (0, 0, 0, 0.05f);
			despertar2.color += new Color (0, 0, 0, 0.05f);
			despertar3.color += new Color (0, 0, 0, 0.05f);
			yield return null;
		}
	
		yield return new WaitForSeconds (5);//4

		while (despertar1.color.a >0) {
			despertar1.color += new Color (0, 0, 0, -0.05f);
			despertar2.color += new Color (0, 0, 0, -0.05f);
			despertar3.color += new Color (0, 0, 0, -0.05f);
			yield return null;
			//print ("chegou aq 0");
		}
			

		yield return new WaitForSeconds (1);
		//print ("chegou aq 1");

		while (white.color.a > 0) {
			white.color += new Color (0, 0, 0, -0.05f);
			yield return null;
			//print ("chegou aq 2");
		}



		//print ("chegou aq 3");

		yield return new WaitForSeconds (1);
		particles.Play ();
		FindObjectOfType<SoundtrackManager> ().StartSoundtrack ();
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(1);
		while (directional.color.r < 0.3f) {
			//directional.intensity += 0.25f;
			if(hand.transform.position.y < initialHandPos.y+1.5f){
				hand.transform.position += new Vector3 (0, 0.015f, 0);
				cs.shakeDuration += 0.25f;
			}
			print ("1 coroutine");
			directional.color += new Color (+0.001f,-0.0025f, -0.0025f);
			yield return null;
		}

		while (hand.transform.position.y < initialHandPos.y+2.5f) {
			hand.transform.position += new Vector3 (0, 0.01f, 0);
			cs.shakeDuration += 0.25f;
			print ("2 coroutine");
			if (directional.color.r < 0.6f) {
				directional.color += new Color (+0.0035f,-0.0025f, -0.0025f);
			}
			if(black.color.a <1){
				black.color += new Color (0, 0, 0, 0.0001f);
			}


			yield return null;
		}


		black.color += new Color (0, 0, 0, 1);
		yield return new WaitForSeconds (2);
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(0);
		yield return new WaitForSeconds (1);
		FindObjectOfType<AudioManager> ().Play ("FXIWin", this.GetComponent<AudioSource> ());
		yield return new WaitForSeconds (2);


		SceneManager.LoadScene ("titleScreen");
		yield break;
	}

}
