using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject scoreUIObject;
	public float score;
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
		scoreUIObject.GetComponent<Text> ().text = "이동거리: 0m";
	}
	
	// Update is called once per frame
	void Update () {
		score = score + PV.scoreSpeed*Time.deltaTime;
		scoreUIObject.GetComponent<Text> ().text = "이동거리: " + (int)(score) + "m";

		if (score <= 1000) {
			playerWalk.SetActive (true);
			playerScooter.SetActive (false);
			playerCar.SetActive (false);

		} 
		else if ((1000 < score) && (score <= 3000)) {
			playerWalk.SetActive (false);
			playerScooter.SetActive (true);
			playerCar.SetActive (false);
		} else {
			playerWalk.SetActive (false);
			playerScooter.SetActive (false);
			playerCar.SetActive (true);
		}
	}
}