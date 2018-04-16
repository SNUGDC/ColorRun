using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject scoreUIObject;
	public GameObject comboCoefUIObject;
	PlayerValue PV;
	public GameObject playerWalk;
	public GameObject playerScooter;
	public GameObject playerCar;


	void Awake()
	{
		PV = FindObjectOfType<PlayerValue>();
		Debug.Log("Score : "+gameObject.name);
	}
	// Use this for initialization
	void Start () {
		LoadScore();
		scoreUIObject.GetComponent<Text> ().text = "이동거리: 0m";
		comboCoefUIObject.SetActive(false);

		Debug.Log ("총 달린 거리: " + PV.sumScore + " / " + PV.nextSumScore);
		Debug.Log ("가장 멀리 간 거리: " + PV.bestScore + " / " + PV.nextBestScore);
		Debug.Log ("총 초록불 통과 개수: " + PV.totalGreenLights + " / " + PV.nextTotalGreenLights);
		Debug.Log ("초록불 최고 연속 통과 개수: " + PV.comboGreenLight + " / " + PV.nextComboGreenLight);
		Debug.Log ("버닝상태 진입 횟수: " + PV.sumBurningCount + " / " + PV.nextSumBurningCount);
		Debug.Log ("지금까지 획득한 아이템 개수: " + PV.sumGetItem + " / " + PV.nextSumGetItem);
		Debug.Log ("최고 속도: " + PV.bestSpeed + " / " + PV.nextBestSpeed);
		Debug.Log ("지금까지 터치한 횟수: " + PV.totalTouch + " / " + PV.nextTotalTouch);
	}

	// Update is called once per frame
	void Update () {
		if(!PV.isPaused && !PV.isGameOvered) {
			var comboCoef = PV.GetComboCoef();
			PV.score += PV.scoreSpeed*Time.deltaTime * comboCoef;
			if (comboCoef > 1.005){
				var n = System.Math.Round((double)comboCoef, 2);
				comboCoefUIObject.SetActive(true);
				comboCoefUIObject.GetComponent<Text>().text = "x"+n;
			} else {
				comboCoefUIObject.SetActive(false);
			}
		}
		scoreUIObject.GetComponent<Text> ().text = (int)(PV.score) + "m";

		if (PV.score <= 1000) {
			playerWalk.SetActive (true);
			playerScooter.SetActive (false);
			playerCar.SetActive (false);

		} else if ((1000 < PV.score) && (PV.score <= 3000)) {
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