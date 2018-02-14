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
	public GameObject player;
	public GameObject burningGaugeObject;
	public GameObject ItemsSpawn;

	void Start () {
		player = GameObject.Find ("Player");
		ItemsSpawn = GameObject.Find ("ItemsSpawn");
		burningGaugeObject = GameObject.Find("BurningGaugeCore");
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		lightIndex = Random.Range (0, 3);
		if (Time.time < burningGaugeObject.GetComponent<BurningGauge> ().startDestroyingTime + 2){
			Destroy (gameObject);
			Debug.Log ("Destroying Seconds: " + (int)(Time.time - burningGaugeObject.GetComponent<BurningGauge> ().startDestroyingTime));
		}
	}

	// Update is called once per frame
	void Update () {
		if (burningGaugeObject.GetComponent<BurningGauge> ().isBurning == true) {
			lightIndex = 0;
		}
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

			if (lightIndex == 1) {
				if (ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability < 20) {
					ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability = 0;
					Debug.Log ("Item Probability: " + ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability + "%");
				} else {
					ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability -= 20;
					Debug.Log ("Item Probability: " + ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability + "%");
				}

				if (burningGaugeObject.GetComponent<BurningGauge> ().isBurning == false) {
					if (burningGaugeObject.GetComponent<BurningGauge> ().burningPoint < 24) {
						burningGaugeObject.GetComponent<BurningGauge> ().burningPoint = 0;
					} else {
						burningGaugeObject.GetComponent<BurningGauge> ().burningPoint -= 24;
					}
				}
			} else if (lightIndex == 0) {
				ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability += 10;
				Debug.Log ("Item Probability: " + ItemsSpawn.GetComponent<ItemSpawn> ().itemProbability + "%");

				if (burningGaugeObject.GetComponent<BurningGauge> ().isBurning == false) {
					burningGaugeObject.GetComponent<BurningGauge> ().burningPoint += 6;
				}
			}
		}
	}
}
