using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsSceneManager : MonoBehaviour {

	public Image white;

	void Start () {
		white.color += new Color (0, 0, 0, -1);
		StartCoroutine (Intro ());
	}
	

	IEnumerator Intro () {

		yield return new WaitForSeconds (1);
		while (white.color.a < 1) {
			white.color += new Color (0, 0, 0, 0.01f);
			yield return null;
		}
		FindObjectOfType<AudioManager> ().Play ("creditSound", this.GetComponent<AudioSource> ());
		yield return new WaitForSeconds (3);



		while (white.color.a > 0) {
			white.color += new Color (0, 0, 0, -0.01f);
			yield return null;
		}


		yield return new WaitForSeconds (1);

		SceneManager.LoadScene ("titleScreen");
		yield break;
	}


}
