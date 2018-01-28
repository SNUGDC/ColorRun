using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLightsColor : MonoBehaviour {

	public Sprite greenLight;
	public Sprite yellowLight;
	public Sprite redLight;
	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = greenLight;
	}

	// Update is called once per frame
	void Update () {
		ChangeLights ();
	}
		
	void ChangeLights(){
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)){
			if (spriteRenderer.sprite == greenLight) {
				spriteRenderer.sprite = yellowLight;
			}
			else if (spriteRenderer.sprite == yellowLight) {
				spriteRenderer.sprite = redLight;
			}
			else if (spriteRenderer.sprite == redLight) {
				spriteRenderer.sprite = greenLight;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (spriteRenderer.sprite == redLight) {
				SceneManager.LoadScene ("MainMenu");
			}
		}
	}
}
