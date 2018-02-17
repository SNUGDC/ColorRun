using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour {

	private Material thisMaterial;
	PlayerValue PV;
	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		thisMaterial = GetComponent<Renderer>().material; 
	}

	void Update () {
		Vector2 newOffset = thisMaterial.mainTextureOffset;
		newOffset.Set(newOffset.x + (PV.scrollSpeed * 0.05f * Time.deltaTime), 0);
		thisMaterial.mainTextureOffset = newOffset;
	}
}