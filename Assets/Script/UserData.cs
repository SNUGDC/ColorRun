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
		NextBestScore ();
	}

	void NextBestScore(){
		PV.bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		if (PV.bestScore > PV.nextBestScore) {
			n2 = n2 + 1;
			PV.nextBestScore = 1000 * n2;
			PlayerPrefs.SetInt ("NextBestScore", PV.nextBestScore);
		}
	}
}
