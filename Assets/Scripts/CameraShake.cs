using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public float shakeLimit;
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 5f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float decreaseFactor = 1.0f;

	Quaternion originalRot;

	void Start()
	{
			originalRot = camTransform.transform.localRotation;
	}



	void Update()
	{
		if (shakeDuration > shakeLimit)
			shakeDuration = shakeLimit;
		if (shakeDuration > 0)
		{
			camTransform.localRotation = Quaternion.Euler(originalRot.x,originalRot.y,originalRot.z +(Random.Range(-1,1) * shakeDuration));

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localRotation = originalRot;
		}
	}
}