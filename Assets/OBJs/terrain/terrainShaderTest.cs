using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainShaderTest : MonoBehaviour {

	Material material;

	float lastn;
	void Start () {
		material = this.GetComponent<Renderer> ().sharedMaterial;
		material.SetFloat("_TopSpread",4);
		StartCoroutine ("Bleed");
	}
	
	// Update is called once per frame
	IEnumerator Bleed () {

		while (material.GetFloat("_TopSpread") > 0) {
			lastn += 0.000001f;
			material.SetFloat("_TopSpread",material.GetFloat("_TopSpread")-lastn);
			yield return null;
		}


		yield break;
	}


}
