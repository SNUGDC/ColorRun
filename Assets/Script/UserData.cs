using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {

	PlayerValue PV;

	public int n1 = 0;
	public int n2 = 0;
	public int n3 = 0;
	public int n4 = 0;
	public int n5 = 0;
	public int n6 = 0;
	public int n7 = 0;
	public int n8 = 0;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}

	void Start() {
		DontDestroyOnLoad (gameObject);
	}

	void Update() {
		NextSumScore ();
		NextBestScore ();
		NextTotalGreenLights ();
		NextComboGreenLight ();
		NextSumBurningCount ();
		NextSumGetItem ();
		NextBestSpeed ();
		NextTotalTouch ();
	}

	void NextSumScore(){
		PV.sumScore = PlayerPrefs.GetInt ("SumScore", 0);
		PV.nextSumScore = PlayerPrefs.GetInt ("NextSumScore", 0);
		if (PV.sumScore >= PV.nextSumScore) {
			n1 = n1 + 1;
			PV.nextSumScore = 5000 * (int)Mathf.Pow(2, n1);
			PlayerPrefs.SetInt ("NextSumScore", PV.nextSumScore);
		}
	}

	void NextBestScore(){
		PV.bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		PV.nextBestScore = PlayerPrefs.GetInt ("NextBestScore", 0);
		if (PV.bestScore >= PV.nextBestScore) {
			n2 = n2 + 1;
			PV.nextBestScore = 1000 * n2;
			PlayerPrefs.SetInt ("NextBestScore", PV.nextBestScore);
		}
	}

	void NextTotalGreenLights(){
		PV.totalGreenLights = PlayerPrefs.GetInt ("TotalGreenLights", 0);
		PV.nextTotalGreenLights = PlayerPrefs.GetInt ("NextTotalGreenLights", 0);
		if (PV.totalGreenLights >= PV.nextTotalGreenLights) {
			n3 = n3 + 1;
			PV.nextTotalGreenLights = 125 * (int)Mathf.Pow(2, n3);
			PlayerPrefs.SetInt ("NextTotalGreenLights", PV.nextTotalGreenLights);
		}
	}

	void NextComboGreenLight(){
		PV.comboGreenLight = PlayerPrefs.GetInt ("ComboGreenLight", 0);
		PV.nextComboGreenLight = PlayerPrefs.GetInt ("NextComboGreenLight", 0);
		if (PV.comboGreenLight >= PV.nextComboGreenLight) {
			n4 = n4 + 1;
			PV.nextComboGreenLight = 10 * n4;
			PlayerPrefs.SetInt ("NextComboGreenLight", PV.nextComboGreenLight);
		}
	}

	void NextSumBurningCount(){
		PV.sumBurningCount = PlayerPrefs.GetInt ("SumBurningCount", 0);
		PV.nextSumBurningCount = PlayerPrefs.GetInt ("NextSumBurningCount", 0);
		if (PV.sumBurningCount >= PV.nextSumBurningCount) {
			n5 = n5 + 1;
			PV.nextSumBurningCount = 5 * n5;
			PlayerPrefs.SetInt ("NextSumBurningCount", PV.nextSumBurningCount);
		}
	}

	void NextSumGetItem(){
		PV.sumGetItem = PlayerPrefs.GetInt ("SumGetItem", 0);
		PV.nextSumGetItem = PlayerPrefs.GetInt ("NextSumGetItem", 0);
		if (PV.sumGetItem >= PV.nextSumGetItem) {
			n6 = n6 + 1;
			PV.nextSumGetItem = 15 * n6;
			PlayerPrefs.SetInt ("NextSumGetItem", PV.nextSumGetItem);
		}
	}

	void NextBestSpeed(){
		PV.bestSpeed = PlayerPrefs.GetFloat ("BestSpeed", 0);
		PV.nextBestSpeed = PlayerPrefs.GetFloat ("NextBestSpeed", 0);
		if (PV.bestSpeed >= PV.nextBestSpeed) {
			n7 = n7 + 1;
			PV.nextBestSpeed = 10 + (5 * n7);
			PlayerPrefs.SetFloat ("NextBestSpeed", PV.nextBestSpeed);
		}
	}

	void NextTotalTouch(){
		PV.totalTouch = PlayerPrefs.GetInt ("TotalTouch", 0);
		PV.nextTotalTouch = PlayerPrefs.GetInt ("NextTotalTouch", 0);
		if (PV.totalTouch >= PV.nextTotalTouch) {
			n8 = n8 + 1;
			PV.nextTotalTouch = 100 * (int)Mathf.Pow(2, n8);
			PlayerPrefs.SetInt ("NextTotalTouch", PV.nextTotalTouch);
		}
	}
}
