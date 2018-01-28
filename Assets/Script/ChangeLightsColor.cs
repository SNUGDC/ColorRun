using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLightsColor : MonoBehaviour {

	//public int[] lightIndex = new int[3]{0,1,2};
	public int lightIndex;
	public Sprite Light0;
	public Sprite Light1;
	public Sprite Light2;
	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		lightIndex = Random.Range (0, 3);
	}

	// Update is called once per frame
	void Update () {
		ChangeLights ();
	}
		
	void ChangeLights(){
		if (lightIndex == 0) {
			spriteRenderer.sprite = Light0;
		} else if (lightIndex == 1) {
			spriteRenderer.sprite = Light1;
		} else if (lightIndex == 2) {
			spriteRenderer.sprite = Light2;
		}
		if (Input.GetKeyDown (KeyCode.Space) || (Input.GetMouseButtonDown(0))){
			if (lightIndex == 0) {
				lightIndex = 1;
			}
			else if (lightIndex == 1) {
				lightIndex = 2;
			}
			else if (lightIndex == 2) {
				lightIndex = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (lightIndex == 2) {
				SceneManager.LoadScene ("MainMenu");
			}
		}
	}
}
