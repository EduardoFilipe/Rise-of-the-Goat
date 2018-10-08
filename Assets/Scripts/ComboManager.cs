using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

	public float timer;
	public int times;
	public float points;
	public bool on = false;
	public Image cross;
	Text text;
	float maxtimer;

	void Awake() {
		text = GetComponent<Text> ();
	}

	public void AddToCombo () {
		on = true;
		times += 1;
		timer += 0.2f;
		points += 1 * times;
		cross.transform.rotation = Quaternion.Euler (new Vector3(0,0,times*-18));
		if (times > 20) {
			FindObjectOfType<PointsManager> ().AddPoints (points+ (points*10));
			points = 0;
			times = 0; 
			cross.transform.rotation = Quaternion.Euler (new Vector3(0,0,0));
		}
		if (timer > 1)
			timer = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text = ((int)(points)).ToString();
		cross.color = new Color (1*timer,0,0,1);
		if (timer > 0)
			timer -= Time.deltaTime/10;
		else { 
			if (on == true) {
				FindObjectOfType<PointsManager> ().AddPoints (points);
				points = 0;
				times = 0;
				on = false;
				cross.transform.rotation = Quaternion.Euler (new Vector3(0,0,0));
			}
		}


	}
}
