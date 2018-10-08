using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	Text hScore;
	// Use this for initialization
	void Awake () {
		hScore = GetComponent<Text> ();
		hScore.text = "1. " + PlayerPrefs.GetInt ("highScore1") + "\n2. " + PlayerPrefs.GetInt ("highScore2") +
		"\n3. " + PlayerPrefs.GetInt ("highScore3") + "\n4. " + PlayerPrefs.GetInt ("highScore4") + "\n5. " + PlayerPrefs.GetInt ("highScore5");
	}
}
