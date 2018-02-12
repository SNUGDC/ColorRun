using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningGauge : MonoBehaviour {

	public Image imageOfBurningGaugeCore;
	
	public float maxBurningPoint;
	public float burningPoint;
	public bool isReadyForBurning;
	public bool isBurning;
	public GameObject player;
	public GameObject trafficLights;
	public GameObject burningGaugeObject;
	float startTime;
	public float startDestroyingTime;
	public float savedSpeed;
	public float alphaSpeed;

	void Start () {
		player = GameObject.Find("Player");
		burningGaugeObject = GameObject.Find("BurningGaugeCore");
		trafficLights = GameObject.Find ("TrafficLightsSpawn");
		isReadyForBurning = false;
		isBurning = false;
		startDestroyingTime = Time.time - 2f;
	}
	
	// Update is called once per frame
	void Update () {

		imageOfBurningGaugeCore.fillAmount = burningGaugeObject.GetComponent<BurningGauge> ().burningPoint / 180f;
		
		if ((burningGaugeObject.GetComponent<BurningGauge> ().burningPoint>=180) && (isReadyForBurning == false)) {
			isReadyForBurning = true;
			startTime = Time.time;
		}

		if (isReadyForBurning == true) {
			if (Time.time < startTime + 5) {
				if ((isBurning == false)) {
					savedSpeed = trafficLights.GetComponent<TrafficLightsScripts> ().scrollSpeed;
					Debug.Log ("속도 저장: " + savedSpeed);
				}
				Burn ();
				isBurning = true;
				Debug.Log ("Burning Seconds: " + (int)(Time.time - startTime));
			} else {
				isReadyForBurning = false;
				isBurning = false;
				alphaSpeed = 0f;
				trafficLights.GetComponent<TrafficLightsScripts> ().scrollSpeed = savedSpeed;
				Debug.Log ("속도 초기화: " + savedSpeed);
				startDestroyingTime = Time.time;
				Debug.Log ("2초 동안 신호등 없음");
			}
		} 

	}

	void Burn () {
		burningGaugeObject.GetComponent<BurningGauge> ().burningPoint -= 36*Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space) || (Input.GetMouseButtonDown (0))) {
			alphaSpeed += 1f;
			Debug.Log ("Speed UP: " + trafficLights.GetComponent<TrafficLightsScripts> ().scrollSpeed);
		}
	}
}
