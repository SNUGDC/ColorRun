using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverWindow;
    public GameObject gameOverScore;
	PlayerValue PV;
	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	// Use this for initialization
    
	void Update() {
        if(PV.isGameOvered == true){
            GameOvered();
        }
	}
    public void GameOvered() {
        
            PV.isPaused = true;
            gameOverWindow.SetActive(true);
           
		gameOverScore.GetComponent<Text> ().text = (int)(PV.score) + "m";
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
		        SceneManager.LoadScene("MainMenu");

            }
    }
}
