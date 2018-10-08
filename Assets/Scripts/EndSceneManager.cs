using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour {

	public FadeTextIn text1, text2;
	// Use this for initialization
	void Start () {
		StartCoroutine (Scene());
	}
	
	// Update is called once per frame
	IEnumerator Scene () {
		yield return new WaitForSeconds (1);

		while (!Input.anyKeyDown) {
			yield return null;
		}
			
		StartCoroutine (text1.FadeOut ());
		StartCoroutine (text2.FadeIn ());
		yield return new WaitForSeconds (0.5f);
		while (!Input.anyKeyDown) {
			yield return null;
		}
		StartCoroutine (text2.FadeIn ());
		yield return new WaitForSeconds (0.5f);
		while (!Input.anyKeyDown) {
			yield return null;
		}
		StartCoroutine (text2.FadeOut ());
		while (!Input.anyKeyDown) {
			yield return null;
		}
		SceneManager.LoadScene ("titleScreen");
		yield break;
	}


}
