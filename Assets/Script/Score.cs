using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject scoreUIObject;
	PlayerValue PV;
	public GameObject playerWalk;
	public GameObject playerScooter;
	public GameObject playerCar;


	void Awake()
	{
		PV = FindObjectOfType<PlayerValue>();
	}
	// Use this for initialization
	void Start () {
		LoadScore();
		scoreUIObject.GetComponent<Text> ().text = "이동거리: 0m";

		Debug.Log ("총 달린 거리: " + PV.sumScore + " / " + PV.nextSumScore);
		Debug.Log ("가장 멀리 간 거리: " + PV.bestScore + " / " + PV.nextBestScore);
		Debug.Log ("총 초록불 통과 개수: " + PV.totalGreenLights + " / " + PV.nextTotalGreenLights);
		Debug.Log ("초록불 최고 연속 통과 개수: " + PV.comboGreenLight + " / " + PV.nextComboGreenLight);
	}
	
	// Update is called once per frame
	void Update () {
		PV.score = PV.score + PV.scoreSpeed*Time.deltaTime;
		scoreUIObject.GetComponent<Text> ().text = "이동거리: " + (int)(PV.score) + "m";

		if (PV.score <= 1000) {
			playerWalk.SetActive (true);
			playerScooter.SetActive (false);
			playerCar.SetActive (false);

		} 
		else if ((1000 < PV.score) && (PV.score <= 3000)) {
			playerWalk.SetActive (false);
			playerScooter.SetActive (true);
			playerCar.SetActive (false);
		} else {
			playerWalk.SetActive (false);
			playerScooter.SetActive (false);
			playerCar.SetActive (true);
		}
	}

	void LoadScore() {
		PV.sumScore = PlayerPrefs.GetInt ("SumScore", 0);
		PV.nextSumScore = PlayerPrefs.GetInt ("NextSumScore", 0);
		PV.bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		PV.nextBestScore = PlayerPrefs.GetInt ("NextBestScore", 0);
		PV.totalGreenLights = PlayerPrefs.GetInt ("TotalGreenLights", 0);
		PV.nextTotalGreenLights = PlayerPrefs.GetInt ("NextTotalGreenLights", 0);
		PV.comboGreenLight = PlayerPrefs.GetInt ("ComboGreenLight", 0);
		PV.nextComboGreenLight = PlayerPrefs.GetInt ("NextComboGreenLight", 0);
	}
}