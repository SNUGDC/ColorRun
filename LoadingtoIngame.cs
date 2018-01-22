using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingtoIngame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int timecount = 50;
		timecount = timecount - 1;
		print (timecount);
		if (timecount < 0){
			SceneManager.LoadScene (2);
		}
	}

	public void Loading_to_Ingame() {

		int timecount = 50;
		while (timecount >= 0) {
			timecount = timecount - 1;
		}
		print (timecount);
		if (timecount < 0) {
			SceneManager.LoadScene (2);
		}
	}



}
