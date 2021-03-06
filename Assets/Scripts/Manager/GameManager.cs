using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject lightManager;
	public GameObject audioDemo;

	public Image endgame, wingame;

	public Text hpText;
	public Text waveText;
	public int wave, waveMax;

	float initialEnemyQty = 5;
	float initialCycleDuration = 2;
	float initialBurst = 6;

	float enemyQty,cycleDur,burst;
	public GameObject enemy, padre;

	Spawner [] spawners;

	public int maxHp, padreqtd;
	public float hp;

	public int enemiesOnScreen;

	public Breakeable[] fences;

	bool startEndingProcedure = false;
	void Awake() {
		//endgame.color -= new Color (0, 0, 0, 1);
		//wingame.color -= new Color (0, 0, 0, 1);
		wave = 0;
		hp = maxHp;
		fences = FindObjectsOfType<Breakeable> ();
		spawners = FindObjectsOfType<Spawner> ();
	}
	void Start () {
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(1);
		NewTurn ();
	}

	void NewTurn () {
		//print ("The wave is being settled.");
		wave++;
		hp += maxHp / 10;
		if (hp > maxHp)
			hp -= hp - maxHp;
		for (int a = 0; a < fences.Length; a++) {
			fences [a].Fix ();
		}

		enemyQty = initialEnemyQty * wave;
		cycleDur = initialCycleDuration + 0.1f * wave;
		burst = 5 + wave;

		lightManager.GetComponent<LightManager> ().NovaWave (wave);

		StartTurn ();
	}

	void StartTurn() {
		print ("The wave is being started.");
		StartCoroutine (DoWave ());
	}

	IEnumerator DoWave() {
		int aleatorio;
		while (enemyQty > 0) {
			aleatorio = Random.Range (0, spawners.Length);
			spawners[aleatorio].Spawn ((int)burst,enemy);
			if (wave >= 3) {
				padreqtd = (wave) / 3;
				spawners [aleatorio].Spawn (padreqtd, padre);
				enemyQty -= padreqtd;
			}
			enemyQty-= burst;
			print ("Spawned " + burst + " and there's still "+enemyQty+ " to go.");
			yield return new WaitForSeconds (cycleDur);
		}

		StartCoroutine (MakePause ());
		yield break;
	}

	IEnumerator MakePause() {
		while (enemiesOnScreen > 0) {
			yield return null;
		}
		if (wave + 1 < waveMax) {
			audioDemo.GetComponent<AudioSource> ().Play ();
			waveText.text = "WAVE " + (wave + 1).ToString ();
			yield return new WaitForSeconds (1);
			StartCoroutine (TriggerWave ());
			print ("Make a pause!");
			yield return new WaitForSeconds (4);

			NewTurn ();
			yield break;
		} else {
			yield return new WaitForSeconds (1);
			Win ();
		}
	}
	// Update is called once per frame



	public void GetDamaged () {

			if (hp > 0) {
				hp-= 0.1f;
			} else {
				hp = 0;
				Lose ();
			}
		
	}

	void Win () {
		FindObjectOfType <PointsManager> ().UpdateHighScore ();
		if (startEndingProcedure == false) {
			startEndingProcedure = true;
			StartCoroutine (WinGame ());
		}

		//print ("You Win");
	}

	void Lose () {
		FindObjectOfType <PointsManager> ().UpdateHighScore ();
		if (startEndingProcedure == false) {
			startEndingProcedure = true;
			StartCoroutine (EndGame());
		}

		//print ("You Lose");

	}

	void Update() {
		hpText.text = hp.ToString();

	}

	IEnumerator TriggerWave() {

		while (waveText.color.a < 1) {
			waveText.color += new Color (0, 0, 0, 0.025f);
			yield return null;
		}

		yield return new WaitForSeconds (2);


		while (waveText.color.a > 0) {
			waveText.color += new Color (0, 0, 0, -0.025f);
			yield return null;
		}
		yield break;
	}

	IEnumerator EndGame () {
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(0);
		while (endgame.color.a < 1) {
			endgame.color += new Color (0, 0, 0, 0.01f);
			yield return null;
		}

		SceneManager.LoadScene ("Lose");
		yield break;
	}
	IEnumerator WinGame () {
		FindObjectOfType<SoundtrackManager> ().FadeToVolume(0);
		while (wingame.color.a < 1) {
			wingame.color += new Color (0, 0, 0, 0.01f);
			yield return null;
		}
		SceneManager.LoadScene ("Win");
		yield break;
	}


}
