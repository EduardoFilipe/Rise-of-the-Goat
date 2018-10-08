using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOnGround : MonoBehaviour {

	public bool x;
	Vector3 normal;
	RaycastHit hit;
	Transform pos;

	public void Align(Transform transform) {
		pos = transform;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
			transform.position = new Vector3 (transform.position.x, hit.point.y-0.05f, transform.position.z);
			normal = hit.normal;

			//transform.localRotation = Quaternion.FromToRotation(transform.up, hit.normal);
			//if (x == true)
			//	transform.localRotation = Quaternion.Euler (new Vector3 (transform.localRotation.x,transform.localRotation.y,pos.localRotation.z));
			//else
			//	transform.localRotation= Quaternion.Euler (new Vector3 (pos.localRotation.x,transform.localRotation.y,transform.localRotation.z));

		}
	
	}

	void Update () {

	}
}
