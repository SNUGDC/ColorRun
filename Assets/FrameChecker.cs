using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameChecker : MonoBehaviour {

	SpriteRenderer renderer;
	public Sprite sprite1;
	public Sprite sprite2;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (renderer.sprite == sprite1) {
			renderer.sprite = sprite2;
		} else {
			renderer.sprite = sprite1;
		}
	}
}
