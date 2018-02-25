using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge : MonoBehaviour {

	public GameObject totalDistanceUI;
	public GameObject nextTotalDistanceUI;
	public GameObject bestDistanceUI;
	public GameObject nextBestDistanceUI;
	public GameObject totalGreenLightsUI;
	public GameObject nextTotalGreenLightsUI;
	public GameObject comboGreenLightUI;
	public GameObject nextComboGreenLightUI;
	public GameObject burningCountUI;
	public GameObject nextBurningCountUI;
	public GameObject getItemUI;
	public GameObject nextGetItemUI;
	public GameObject bestSpeedUI;
	public GameObject nextBestSpeedUI;
	public GameObject totalTouchUI;
	public GameObject nextTotalTouchUI;
	PlayerValue PV;

	void Awake()
	{
		PV = FindObjectOfType<PlayerValue>();
	}

	void Start () {
		Load ();

		totalDistanceUI.GetComponent<Text> ().text = PV.sumScore + "m";
		nextTotalDistanceUI.GetComponent<Text> ().text = PV.nextSumScore + "m";
		bestDistanceUI.GetComponent<Text> ().text = PV.bestScore + "m";
		nextBestDistanceUI.GetComponent<Text> ().text = PV.nextBestScore + "m";
		totalGreenLightsUI.GetComponent<Text> ().text = PV.totalGreenLights + "개";
		nextTotalGreenLightsUI.GetComponent<Text> ().text = PV.nextTotalGreenLights + "개";
		comboGreenLightUI.GetComponent<Text> ().text = PV.comboGreenLight + "개";
		nextComboGreenLightUI.GetComponent<Text> ().text = PV.nextComboGreenLight + "개";
		burningCountUI.GetComponent<Text> ().text = PV.sumBurningCount + "번";
		nextBurningCountUI.GetComponent<Text> ().text = PV.nextSumBurningCount + "번";
		getItemUI.GetComponent<Text> ().text = PV.sumGetItem + "개";
		nextGetItemUI.GetComponent<Text> ().text = PV.nextSumGetItem + "개";
		bestSpeedUI.GetComponent<Text> ().text = PV.bestSpeed + "km/h";
		nextBestSpeedUI.GetComponent<Text> ().text = PV.nextBestSpeed + "km/h";
		totalTouchUI.GetComponent<Text> ().text = PV.totalTouch + "번";
		nextTotalTouchUI.GetComponent<Text> ().text = PV.nextTotalTouch + "번";
	}
		
	void Update () {
		
	}

	void Load() {
		PV.sumScore = PlayerPrefs.GetInt ("SumScore", 0);
		PV.nextSumScore = PlayerPrefs.GetInt ("NextSumScore", 0);
		PV.bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		PV.nextBestScore = PlayerPrefs.GetInt ("NextBestScore", 0);
		PV.totalGreenLights = PlayerPrefs.GetInt ("TotalGreenLights", 0);
		PV.nextTotalGreenLights = PlayerPrefs.GetInt ("NextTotalGreenLights", 0);
		PV.comboGreenLight = PlayerPrefs.GetInt ("ComboGreenLight", 0);
		PV.nextComboGreenLight = PlayerPrefs.GetInt ("NextComboGreenLight", 0);
		PV.sumBurningCount = PlayerPrefs.GetInt ("SumBurningCount", 0);
		PV.nextSumBurningCount = PlayerPrefs.GetInt ("NextSumBurningCount", 0);
		PV.sumGetItem = PlayerPrefs.GetInt ("SumGetItem", 0);
		PV.nextSumGetItem = PlayerPrefs.GetInt ("NextSumGetItem", 0);
		PV.bestSpeed = PlayerPrefs.GetFloat ("BestSpeed", 0);
		PV.nextBestSpeed = PlayerPrefs.GetFloat ("NextBestSpeed", 0);
		PV.totalTouch = PlayerPrefs.GetInt ("TotalTouch", 0);
		PV.nextTotalTouch = PlayerPrefs.GetInt ("NextTotalTouch", 0);
	}
}
