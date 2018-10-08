using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateOnBeggining : MonoBehaviour {

	void Start() {
	
		this.GetComponent<Image> ().color += new Color (0, 0, 0, 1);
		StartCoroutine (FadeOut ());
	}

	IEnumerator FadeOut () {
		while (this.GetComponent<Image> ().color.a > 0) {
			this.GetComponent<Image> ().color += new Color (0, 0, 0, -0.01f);
			yield return null;
		}
	
		yield break;
	}

}
