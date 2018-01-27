using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject burning;
	public GameObject burnPointUIObject;
	public GameObject scoreUIObject;
	public int burnPoint;
	public int score;

	// Use this for initialization
	void Start () {
		scoreUIObject.GetComponent<Text> ().text = "이동거리: 0m";
	}
	
	// Update is called once per frame
	void Update () {
		score += 1;
		scoreUIObject.GetComponent<Text> ().text = "이동거리: " + score + "m";
	}
}