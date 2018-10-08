using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeTextIn : MonoBehaviour {

	public bool onStart;
	// Use this for initialization
	void Start () {
		if(onStart)	
		StartCoroutine (FadeIn ());

	}
	
	// Update is called once per frame
	public IEnumerator FadeIn () {
		while (GetComponent<Text> ().color.a < 1) {
			GetComponent<Text> ().color += new Color (0, 0, 0, +0.02f);
			yield return null;
		}
		yield break;
	}
	public IEnumerator FadeOut () {
		while (GetComponent<Text> ().color.a > 0 ) {
			GetComponent<Text> ().color += new Color (0, 0, 0, -0.02f);
			yield return null;
		}
		yield break;
	}
}
