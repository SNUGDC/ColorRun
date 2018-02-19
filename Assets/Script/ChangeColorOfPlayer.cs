using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColorOfPlayer : MonoBehaviour {

	//colorOfPlayer = 0 (green) 1(yellow) 2(red)
	GameObject playerName;
	PlayerValue PV;
	public Sprite[] players;
	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		PV.colorOfPlayer = 0;
	}
	

	public void RightChangePlayer() {
		if(PV.colorOfPlayer == 0){
			PV.colorOfPlayer = 1;
			this.GetComponent<SpriteRenderer>().sprite = players[PV.colorOfPlayer];
			playerName = GameObject.Find("초이");
			playerName.SetActive(false);
			playerName=GameObject.Find("노아");
			playerName.SetActive(true);
		}
		if(PV.colorOfPlayer == 1){
			PV.colorOfPlayer = 2;
			GetComponent<SpriteRenderer>().sprite = players[PV.colorOfPlayer];
			GameObject.Find("노아").SetActive(false);
			GameObject.Find("뽀이").SetActive(true);
		}
		if(PV.colorOfPlayer == 2){
			PV.colorOfPlayer = 0;
			GetComponent<SpriteRenderer>().sprite = players[PV.colorOfPlayer];
			GameObject.Find("뽀이").SetActive(false);
			GameObject.Find("초이").SetActive(true);
		}
		Debug.Log(PV.colorOfPlayer);
	}

	public void LeftChangePlayer() {
		if(PV.colorOfPlayer == 0){
			PV.colorOfPlayer = 2;
			GetComponent<SpriteRenderer>().sprite = players[PV.colorOfPlayer];
			GameObject.Find("초이").SetActive(false);
			GameObject.Find("뽀이").SetActive(true);
		}
		if(PV.colorOfPlayer == 1){
			PV.colorOfPlayer = 0;
			GetComponent<SpriteRenderer>().sprite = players[PV.colorOfPlayer];
			GameObject.Find("노아").SetActive(false);
			GameObject.Find("초이").SetActive(true);
		}
		if(PV.colorOfPlayer == 2){
			PV.colorOfPlayer = 1;
			GetComponent<SpriteRenderer>().sprite = players[PV.colorOfPlayer];
			GameObject.Find("뽀이").SetActive(false);
			GameObject.Find("노아").SetActive(true);
		}
	}

}
