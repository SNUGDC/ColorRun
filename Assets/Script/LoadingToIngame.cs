using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingToIngame : MonoBehaviour {

	int timecount = 50;
	public string sceneName;
	// Use this for initialization
	void Start () {
		

	}

	void Update()
	{
		timecount = timecount - 1;
		Debug.Log(timecount);
		if (timecount < 0){
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
