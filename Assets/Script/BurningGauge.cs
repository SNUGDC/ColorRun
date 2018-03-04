using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningGauge : MonoBehaviour {

	public Image imageOfBurningGaugeCore;
	float startTime;
	public float startDestroyingTime;
	PlayerValue PV;
	public Image imageOfBurningGaugeEmpty;
	public Sprite gaugeWhite;
	public Sprite gaugeRed;
	int frameCounter;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		PV.isReadyForBurning = false;
		PV.isBurning = false;
		PV.afterBurningDelay = 0;
		imageOfBurningGaugeEmpty.enabled = true;
		startDestroyingTime = Time.time - 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if(PV.isPaused) return;

		imageOfBurningGaugeCore.fillAmount = PV.burningPoint / 180f;
		if(!PV.isBurning) PV.afterBurningDelay -= Time.deltaTime;

		if ((PV.burningPoint>=180) && (PV.isReadyForBurning == false)) {
			PV.isReadyForBurning = true;
			startTime = Time.time;
		}

		if (PV.isReadyForBurning == true) {
			//Debug.Log("BurningTime : "+(Time.time - startTime));
			if (Time.time < startTime + 5) {
				if ((PV.isBurning == false)) {
					PV.savedScrollSpeed = PV.scrollSpeed;
					PV.savedScoreSpeed = PV.scoreSpeed;
					PV.afterBurningDelay = 0.05f;
					frameCounter = 0;
					//Debug.Log ("속도 저장: " + PV.savedScrollSpeed);
					PV.burningCount += 1;
					SoundManager.PlayBurning();
				}
				Burn ();
				PV.isBurning = true;
			} else {
				PV.isReadyForBurning = false;
				PV.isBurning = false;
				imageOfBurningGaugeEmpty.enabled = true;
				SoundManager.StopBurning();
				PV.alphaSpeed = 0f;
				PV.scrollSpeed = PV.savedScrollSpeed;
				PV.afterBurningDelay = 2;
				imageOfBurningGaugeEmpty.sprite = gaugeWhite;
				//Debug.Log ("속도 초기화: " + PV.savedScrollSpeed);
				startDestroyingTime = Time.time;
				//Debug.Log ("2초 동안 신호등 없음");
			}
		} 

	}

	void Burn () {
		PV.burningPoint -= 36*Time.deltaTime;
		//BurningGaugeBurn.SetActive (true);
		//imageOfBurningGaugeEmpty.enabled = false;

		if (frameCounter < 3) imageOfBurningGaugeEmpty.sprite = gaugeWhite;
		else {
			imageOfBurningGaugeEmpty.sprite = gaugeRed;
			if(frameCounter > 5){
				frameCounter = 0;
			}
		}
		frameCounter++;
	}
}
