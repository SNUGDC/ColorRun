using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningGauge : MonoBehaviour {

	public Image imageOfBurningGaugeCore;
	float startTime;
	public float startDestroyingTime;
	PlayerValue PV;
	public GameObject BurningGaugeBurn;
	public Image imageOfBurningGaugeEmpty;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		PV.isReadyForBurning = false;
		PV.isBurning = false;
		BurningGaugeBurn.SetActive (false);
		imageOfBurningGaugeCore.enabled = true;
		imageOfBurningGaugeEmpty.enabled = true;
		startDestroyingTime = Time.time - 2f;
	}
	
	// Update is called once per frame
	void Update () {

		imageOfBurningGaugeCore.fillAmount = PV.burningPoint / 180f;
		
		if ((PV.burningPoint>=180) && (PV.isReadyForBurning == false)) {
			PV.isReadyForBurning = true;
			startTime = Time.time;
		}

		if (PV.isReadyForBurning == true) {
			if (Time.time < startTime + 5) {
				if ((PV.isBurning == false)) {
					PV.savedScrollSpeed = PV.scrollSpeed;
					PV.savedScoreSpeed = PV.scoreSpeed;
					Debug.Log ("속도 저장: " + PV.savedScrollSpeed);
				}
				Burn ();
				PV.isBurning = true;
				Debug.Log ("Burning Seconds: " + (int)(Time.time - startTime));
			} else {
				PV.isReadyForBurning = false;
				PV.isBurning = false;
				BurningGaugeBurn.SetActive (false);
				imageOfBurningGaugeCore.enabled = true;
				imageOfBurningGaugeEmpty.enabled = true;
				PV.alphaSpeed = 0f;
				PV.scrollSpeed = PV.savedScrollSpeed;
				Debug.Log ("속도 초기화: " + PV.savedScrollSpeed);
				startDestroyingTime = Time.time;
				Debug.Log ("2초 동안 신호등 없음");
			}
		} 

	}

	void Burn () {
		PV.burningPoint -= 36*Time.deltaTime;
		BurningGaugeBurn.SetActive (true);
		imageOfBurningGaugeCore.enabled = false;
		imageOfBurningGaugeEmpty.enabled = false;
	}
}
