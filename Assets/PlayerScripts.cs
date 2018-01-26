using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public float speed;

	// Update is called once per frame
	void Update () {
		MoveControl ();
	}

	void MoveControl(){
		if (Input.GetKeyDown (KeyCode.UpArrow) && (transform.position.y <= 0 )) {
			transform.position += Vector3.up * speed;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && (transform.position.y >= 0 )) {
			transform.position += Vector3.down * speed;
		}
	}
}
