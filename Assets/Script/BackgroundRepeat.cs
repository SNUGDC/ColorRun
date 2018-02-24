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
		if(PV.isPaused) return;
		
		Vector2 newOffset = thisMaterial.mainTextureOffset;
		newOffset.Set(newOffset.x + (PV.scrollSpeed * 0.02f * Time.deltaTime), 0);
		thisMaterial.mainTextureOffset = newOffset;
	}
}