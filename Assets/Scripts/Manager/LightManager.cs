using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {
	GameObject[] postes;
	public GameObject gameManager;

	public Light[] luzPoste;
	public Light igreja, mundo;

	public bool piscar, ligar;

	// Use this for initialization
	void Start () {
		postes = GameObject.FindGameObjectsWithTag("Poste");
		luzPoste = new Light[postes.Length];
		for (int i = 0; i < postes.Length; i++) {
			luzPoste [i] = postes [i].GetComponent<Light> ();
		}
		for (int i = 0; i < luzPoste.Length; i++) {
			ApagarPoste (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GetComponent<GameManager> ().wave == 6) {
			ligar = true;
			piscar = false;
			StartCoroutine (AscenderPoste ());
		}
		if (gameManager.GetComponent<GameManager> ().wave == 8) {
			piscar = true;
			ligar = false;
			StartCoroutine (PiscarPoste ());
		}
	}

	void ApagarPoste (int i) {
		luzPoste [i].intensity = 0;
	}

	public void AlterarIntensidadeLuz (float qtd, Light luz){
		if (luz.intensity > 1 && luz.intensity < 7) {
			luz.intensity += qtd;
		}
	}

	public void NovaWave (int wave){
		AlterarIntensidadeLuz (wave / 5, igreja);
		AlterarIntensidadeLuz (-wave / 5, mundo);
	}

	IEnumerator AscenderPoste() {
		for (int i = 0; i < luzPoste.Length; i++) {
			while (luzPoste [i].intensity < 4) {
				luzPoste [i].intensity += 0.5f;
				yield return new WaitForSeconds (1f);
			}
		}
		yield break;
	}

	IEnumerator PiscarPoste() {
		while (piscar) {
			yield return new WaitForSeconds (0.5f);
			for (int i = 0; i < luzPoste.Length; i++) {
				luzPoste [i].intensity = 0;
			}

			yield return new WaitForSeconds (0.5f);
			for (int i = 0; i < luzPoste.Length; i++) {
				luzPoste [i].intensity = 4;
			}
		}
		yield break;
	}
}
