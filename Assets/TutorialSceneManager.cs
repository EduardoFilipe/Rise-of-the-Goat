using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneManager : MonoBehaviour {

	public Image redBg;
	public Text[] texts;
	bool conti =false;
	// Use this for initialization
	void Start () {
		//redBg.color = new Color (191/255, 0, 0, 1);
		foreach (Text text in texts) {
			text.color += new Color (0, 0, 0, -1f);
		}
		StartCoroutine (DoTutorial ());
	}

	IEnumerator DoTutorial () {

		while (redBg.color.r > 0) {
			redBg.color += new Color (-0.01f, 0, 0, 0);
			yield return null;
		}

		while (texts [0].color.a < 1) {
			foreach (Text text in texts) {
				text.color += new Color (0, 0, 0, 0.01f);
			}
			yield return null;
		}


		while (conti == false) {
			if (Input.anyKeyDown)
				conti = true;
			yield return null;
		}


		while (texts [0].color.a > 0) {
			foreach (Text text in texts) {
				text.color += new Color (0, 0, 0, -0.01f);
			}
			yield return null;
		}

		while (redBg.color.r < 1) {
			redBg.color += new Color (0.01f, 0, 0, 0);
			yield return null;
		}
		SceneManager.LoadScene ("game");

		yield break;
	}

}
