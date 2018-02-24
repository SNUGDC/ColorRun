using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour {

	float z;
	PlayerValue PV;
	void Awake () {
		PV = FindObjectOfType<PlayerValue>();
	}

	// Update is called once per frame
	void Update () {
		z -= Time.deltaTime * PV.scrollSpeed * 100;
		transform.rotation = Quaternion.Euler (0, 0, z);
	}
}
