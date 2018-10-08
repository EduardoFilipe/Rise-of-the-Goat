using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {
	public GameObject gameManager;
	public int pontuacao = 0;
	public Text pontTxt, hScoreTxt;

	void Awake() {
		pontTxt = GetComponent<Text> ();
	}

	public void AddPoints (float points){
		pontuacao += (int)points;
	}

	void Update () {
		if( pontuacao > 0)
		pontTxt.text = "Sangue: " + pontuacao;
	}
	
	public void UpdateHighScore () {
		PlayerPrefs.SetInt ("highScoreAtual",pontuacao);
		if (pontuacao > PlayerPrefs.GetInt ("highScore5")) {
			if (pontuacao > PlayerPrefs.GetInt ("highScore4")) {
				if (pontuacao > PlayerPrefs.GetInt ("highScore3")) {
					if (pontuacao > PlayerPrefs.GetInt ("highScore2")) {
						if (pontuacao > PlayerPrefs.GetInt ("highScore1")) {
							PlayerPrefs.SetInt ("highScore5", PlayerPrefs.GetInt ("highScore4"));
							PlayerPrefs.SetInt ("highScore4", PlayerPrefs.GetInt ("highScore3"));
							PlayerPrefs.SetInt ("highScore3", PlayerPrefs.GetInt ("highScore2"));
							PlayerPrefs.SetInt ("highScore2", PlayerPrefs.GetInt ("highScore1"));
							PlayerPrefs.SetInt ("highScore1", pontuacao);
						} else {
							PlayerPrefs.SetInt ("highScore5", PlayerPrefs.GetInt ("highScore4"));
							PlayerPrefs.SetInt ("highScore4", PlayerPrefs.GetInt ("highScore3"));
							PlayerPrefs.SetInt ("highScore3", PlayerPrefs.GetInt ("highScore2"));
							PlayerPrefs.SetInt ("highScore2", pontuacao);
						}
					} else {
						PlayerPrefs.SetInt ("highScore5", PlayerPrefs.GetInt ("highScore4"));
						PlayerPrefs.SetInt ("highScore4", PlayerPrefs.GetInt ("highScore3"));
						PlayerPrefs.SetInt ("highScore3", pontuacao);
					}
				} else {
					PlayerPrefs.SetInt ("highScore5", PlayerPrefs.GetInt ("highScore4"));
					PlayerPrefs.SetInt ("highScore4", pontuacao);
				}
			} else {
				PlayerPrefs.SetInt ("highScore5", pontuacao);
			}
		}
	}
}
