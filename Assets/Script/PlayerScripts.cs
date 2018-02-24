using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	TrafficLightsScripts trafficManager;
	ItemSpawn itemsSpawn;
	PlayerValue PV;
	float logBase = 1.6f;
	float scoreTime;
	public GameObject sunglasses;
	public GameObject police;

	void Start (){
		PV = FindObjectOfType<PlayerValue>();
		trafficManager = FindObjectOfType<TrafficLightsScripts>();
		itemsSpawn = FindObjectOfType<ItemSpawn>();
		PV.policePoint = 0;
		PV.sunglassPoint = 0;
		scoreTime = Time.time;
		PV.colorOfPlayer = PlayerPrefs.GetInt("colorOfPlayer");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "trafficlight") {
			itemsSpawn.GenerateRandomItem ();
		}
	}

	float GetTime()
	{
		return Time.time - PV.initTime;
	}
	void Update() {
		GetInput ();

		if (GetTime () <= 1.0f) {
			
		} else {
			PV.scrollSpeed += Mathf.Log (2.718281f, logBase) * Time.deltaTime / GetTime () + PV.alphaSpeed * Time.deltaTime;
			PV.scoreSpeed += Mathf.Log (2.718281f, logBase) * Time.deltaTime / (Time.time - scoreTime) + PV.alphaSpeed * Time.deltaTime;
			PV.frequency = PV.scrollSpeed / 20 * (GetTime () / 60 + 1);
		}

		if (PV.policePoint == 1) {
			police.SetActive (true);
		} else {
			police.SetActive (false);
		}
		if (PV.sunglassPoint == 1) {
			sunglasses.SetActive (true);
		} else {
			sunglasses.SetActive (false);
		}
	}
	void GetInput(){
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {

			trafficManager.ChangeColor();
			if(PV.isBurning){
				PV.alphaSpeed += 1f;
				SoundManager.Play(SoundType.BurningChangeLight);
				Debug.Log ("Speed UP: " + PV.scrollSpeed);
			} else {
				trafficManager.ChangeColor();
				SoundManager.Play(SoundType.ChangeLight);
			}
		}
	}
}