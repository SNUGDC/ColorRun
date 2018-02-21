using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	GameObject pauseWindow;
	PlayerValue PV;
	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	// Use this for initialization
	public void LetPaused() {
		PV.isPaused = true;
		pauseWindow = GameObject.Find("PauseWindow");
		pauseWindow.SetActive(true);


	}
	public void LetContinued(){
		PV.isPaused = false;
		pauseWindow = GameObject.Find("PauseWindow");
		pauseWindow.SetActive(false);

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
