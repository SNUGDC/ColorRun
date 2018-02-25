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
	public GameObject charGWalking;
	public GameObject charYWalking;
	public GameObject charRWalking;
	public GameObject charRiding;
	public Sprite charGRiding;
	public Sprite charYRiding;
	public Sprite charRRiding;
	public GameObject charNoLegs;
	public Sprite charGNoLegs;
	public Sprite charYNoLegs;
	public Sprite charRNoLegs;

	void Start (){
		PV = FindObjectOfType<PlayerValue>();
		trafficManager = FindObjectOfType<TrafficLightsScripts>();
		itemsSpawn = FindObjectOfType<ItemSpawn>();
		PV.policePoint = 0;
		PV.sunglassPoint = 0;
		scoreTime = Time.time;
		PV.colorOfPlayer = PlayerPrefs.GetInt("colorOfPlayer");
		charGWalking.SetActive (false);
		charYWalking.SetActive (false);
		charRWalking.SetActive (false);
		ChooseColor ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.tag == "trafficlight") && (PV.isBurning == false)) {
			itemsSpawn.GenerateRandomItem ();
		}
	}

	float GetTime()
	{
		return Time.time - PV.initTime;
	}
	void Update() {
		if(PV.isPaused) return;

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
			PV.totalTouch += 1;

			if(PV.isBurning){
				PV.alphaSpeed += 1f;
				SoundManager.Play(SoundType.BurningChangeLight);
				//Debug.Log ("Speed UP: " + PV.scrollSpeed);
			} else if (PV.afterBurningDelay <= 0) {
				trafficManager.ChangeColor();
				SoundManager.Play(SoundType.ChangeLight);
			}
		}
	}

	void ChooseColor() {
		if (PV.colorOfPlayer == 0) {
			if (gameObject.name == "Walk") {
				charGWalking.SetActive (true);
				charYWalking.SetActive (false);
				charRWalking.SetActive (false);
			} else if (gameObject.name == "Scooter") {
				charRiding.GetComponent<SpriteRenderer> ().sprite = charGRiding;
			} else if (gameObject.name == "Car") {
				charNoLegs.GetComponent<SpriteRenderer> ().sprite = charGNoLegs;
			}
		} else if (PV.colorOfPlayer == 1) {
			if (gameObject.name == "Walk") {
				charGWalking.SetActive (false);
				charYWalking.SetActive (true);
				charRWalking.SetActive (false);
			} else if (gameObject.name == "Scooter") {
				charRiding.GetComponent<SpriteRenderer> ().sprite = charYRiding;
			} else if (gameObject.name == "Car") {
				charNoLegs.GetComponent<SpriteRenderer> ().sprite = charYNoLegs;
			}
		} else if (PV.colorOfPlayer == 2) {
			if (gameObject.name == "Walk") {
				charGWalking.SetActive (false);
				charYWalking.SetActive (false);
				charRWalking.SetActive (true);
			} else if (gameObject.name == "Scooter") {
				charRiding.GetComponent<SpriteRenderer> ().sprite = charRRiding;
			} else if (gameObject.name == "Car") {
				charNoLegs.GetComponent<SpriteRenderer> ().sprite = charRNoLegs;
			}
		}
	}
}