using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {


	void Start () {
		this.GetComponent<Image> ().color += new Color (0, 0, 0, 1f);
		StartCoroutine (FadeOutNow ());
	}

	IEnumerator FadeOutNow() {

		while (this.GetComponent<Image> ().color.a > 0) {
			this.GetComponent<Image> ().color += new Color (0, 0, 0, -0.01f);
			yield return null;
		}
		yield break;
	}

}
