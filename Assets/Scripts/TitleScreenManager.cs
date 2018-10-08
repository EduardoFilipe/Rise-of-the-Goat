using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {
	int state= 1;
	public ParticleSystem sidePart,upPart;
	public Text TITLE1,TITLE2;

	public Text play,hs1,hs2,quit;

	public Image endScreen;

	void Start() {
		Cursor.visible = true;
		endScreen.color += new Color (0, 0, 0, -1f);
		TITLE1.color += new Color (0, 0, 0, 1f);
		TITLE2.color += new Color (0, 0, 0, 1f);
		play.color += new Color (0, 0, 0, -1f);
		hs1.color += new Color (0, 0, 0, -1f);
		hs2.color += new Color (0, 0, 0, -1f);
		quit.color += new Color (0, 0, 0, -1f);
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(1);

		StartCoroutine(RunMenu());
	}

	IEnumerator RunMenu() {
		state = 1;
			
			yield return new WaitForSeconds (2);
		FindObjectOfType<AudioManager> ().Play ("inimigoExplodindo", this.GetComponent<AudioSource> ());
			sidePart.Play ();

			yield return new WaitForSeconds (3);

			while (TITLE1.color.a > 0) {
				TITLE1.color += new Color (0, 0, 0, -0.1f);
				TITLE2.color += new Color (0, 0, 0, -0.1f);
				yield return null;
			}

			while (play.color.a <1) {
				play.color += new Color (0, 0, 0, +0.035f);
				hs1.color += new Color (0, 0, 0, +0.035f);
				hs2.color += new Color (0, 0, 0, +0.035f);
				quit.color += new Color (0, 0, 0, +0.035f);
				yield return null;
			}



			state = 9;

		yield break;

	}


	public void LoadNewScene (string scene) {
		if (state >= 9)
			StartCoroutine (NewGame (scene));
	}

	IEnumerator NewGame(string scene) {

		state = 10;
		yield return new WaitForSeconds (1);
		FindObjectOfType<AudioManager> ().Play ("inimigoExplodindo", this.GetComponent<AudioSource> ());
			upPart.Play ();
			
		yield return new WaitForSeconds (2);
		FindObjectOfType<AudioManager> ().Play ("titleLaugh", this.GetComponent<AudioSource> ());
		yield return new WaitForSeconds (1);
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(0);
		while (endScreen.color.a < 1) {
			endScreen.color += new Color (0, 0, 0, 0.025f);
			yield return null;
		}

			SceneManager.LoadScene (scene);

			yield break;

	}

	public void Quit () {
		if(state >= 9)
			Application.Quit ();
	}
}
