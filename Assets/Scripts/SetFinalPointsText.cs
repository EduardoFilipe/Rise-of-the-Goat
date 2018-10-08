using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFinalPointsText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().text += "\n"+PlayerPrefs.GetInt ("highScoreAtual");
	}
	

}
