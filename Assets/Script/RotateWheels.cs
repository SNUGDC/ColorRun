using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour {

	float z;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		z -= Time.deltaTime * 500;
		transform.rotation = Quaternion.Euler (0, 0, z);
	}
}
