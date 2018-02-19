using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject scoreUIObject;
	public float score;
	PlayerValue PV;

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
	}
}