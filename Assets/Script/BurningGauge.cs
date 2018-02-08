using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningGauge : MonoBehaviour {

	public Image imageOfBurningGaugeCore;
	
	public float maxBurningPoint;
	public float burningPoint;
	public bool isPlayerBuring;
	GameObject player;
	GameObject burningGaugeObject;
	void Start () {
		player = GameObject.Find("Player");
		burningGaugeObject = GameObject.Find("BurningGaugeCore");
		isPlayerBuring = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		imageOfBurningGaugeCore.fillAmount = burningGaugeObject.GetComponent<BurningGauge> ().burningPoint / 180f;
		
		if(burningGaugeObject.GetComponent<BurningGauge> ().burningPoint <= 0){
			isPlayerBuring = false;
		}
		else(burningGaugeObject.GetComponent<BurningGauge> ().burningPoint>=180){
			isPlayerBuring = true;
		}
		
		if(isPlayerBuring){
			burningGaugeObject.GetComponent<BurningGauge> ().burningPoint -= 36* Time.deltaTime;
		}

		
	}
}
