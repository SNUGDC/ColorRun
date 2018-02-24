using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {

	PlayerValue PV;

	public int n1 = 0;
	public int n2 = 0;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}

	void Start() {
		DontDestroyOnLoad (gameObject);
	}

	void Update() {
		NextSumScore ();
		NextBestScore ();
	}

	void NextSumScore(){
		PV.sumScore = PlayerPrefs.GetInt ("SumScore", 0);
		PV.nextSumScore = PlayerPrefs.GetInt ("NextSumScore", 0);
		if (PV.sumScore > PV.nextSumScore) {
			n1 = n1 + 1;
			PV.nextSumScore = 5000 * (int)Mathf.Pow(2, n1);
			PlayerPrefs.SetInt ("NextSumScore", PV.nextSumScore);
		}
	}

	void NextBestScore(){
		PV.bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		PV.nextBestScore = PlayerPrefs.GetInt ("NextBestScore", 0);
		if (PV.bestScore > PV.nextBestScore) {
			n2 = n2 + 1;
			PV.nextBestScore = 1000 * n2;
			PlayerPrefs.SetInt ("NextBestScore", PV.nextBestScore);
		}
	}
}
