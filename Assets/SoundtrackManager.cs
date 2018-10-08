using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour {

	AudioSource aS;

	void Start() {
		aS = this.GetComponent<AudioSource> ();
	}
	public void StartSoundtrack() {

		aS.Play ();

	}

	public void FadeToVolume(float toVolume) {
		StartCoroutine (FadeVolume (toVolume));
	}

	IEnumerator FadeVolume(float toVolume) {
		if (toVolume > 1)
			toVolume = 1;
		else if (toVolume < 0)
			toVolume = 0;


		while (aS.volume < toVolume) {

			aS.volume += 0.05f;
			yield return null;
		}

		while (aS.volume > toVolume) {
			aS.volume -= 0.05f;
			yield return null;
		}



		yield break;
	}




}
