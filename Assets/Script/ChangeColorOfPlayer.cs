using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeColorOfPlayer : MonoBehaviour {

	//colorOfPlayer = 0 (green) 1(yellow) 2(red)
	GameObject playerName;
	PlayerValue PV;
	public Sprite[] players;
	public GameObject nameGreen;
	public GameObject nameYellow;
	public GameObject nameRed;
	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		PV.colorOfPlayer = PlayerPrefs.GetInt("colorOfPlayer");
	}
	
	void Update() {
			GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			if(PV.colorOfPlayer == 0){
				nameGreen.SetActive(true);
				nameYellow.SetActive(false);
				nameRed.SetActive(false);
			}
			else if(PV.colorOfPlayer == 1){
				nameGreen.SetActive(false);
				nameYellow.SetActive(true);
				nameRed.SetActive(false);
			}
			else if(PV.colorOfPlayer == 2){
				nameGreen.SetActive(false);
				nameYellow.SetActive(false);
				nameRed.SetActive(true);
			}
	}
	public void RightChangePlayer() {
		if(PV.colorOfPlayer == 0){
			PV.colorOfPlayer = 1;
			PlayerPrefs.SetInt("colorOfPlayer",1);
			//GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			nameGreen.SetActive(false);
			nameYellow.SetActive(true);
		}
		else if(PV.colorOfPlayer == 1){
			PV.colorOfPlayer = 2;
			PlayerPrefs.SetInt("colorOfPlayer",2);
			//GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			nameYellow.SetActive(false);
			nameRed.SetActive(true);
		}
		else if(PV.colorOfPlayer == 2){
			PV.colorOfPlayer = 0;
			PlayerPrefs.SetInt("colorOfPlayer",0);
			//GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			nameRed.SetActive(false);
			nameGreen.SetActive(true);
			//GameObject.Find("뽀야").SetActive(false);
			//GameObject.Find("초야").SetActive(true);
		}
			Debug.Log(PV.colorOfPlayer);
	}

	public void LeftChangePlayer() {
		if(PV.colorOfPlayer == 0){
			PV.colorOfPlayer = 2;
			PlayerPrefs.SetInt("colorOfPlayer",2);
			//GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			nameGreen.SetActive(false);
			nameRed.SetActive(true);
		}
		else if(PV.colorOfPlayer == 1){
			PV.colorOfPlayer = 0;
			PlayerPrefs.SetInt("colorOfPlayer",0);
			//GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			nameYellow.SetActive(false);
			nameGreen.SetActive(true);
		}
		else if(PV.colorOfPlayer == 2){
			PV.colorOfPlayer = 1;
			PlayerPrefs.SetInt("colorOfPlayer",1);
			//GetComponent<Image>().sprite = players[PV.colorOfPlayer];
			nameRed.SetActive(false);
			nameYellow.SetActive(true);
		}
			Debug.Log(PV.colorOfPlayer);
	}

}
