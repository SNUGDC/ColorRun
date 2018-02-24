using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TrafficType { Two, Three, Four, ThreeReverse }
[System.Serializable]
public class TrafficDic{
	public TrafficType type;
	public Sprite[] sprites;
}
public class ChangeLightsColor : MonoBehaviour {
	
	//public int[] lightIndex = new int[3]{0,1,2};

	//index = 0 : green
	int trafficType;
	public int lightIndex;
	public int maxIndex; //기본신호등 maxIndex=3
	public bool isReversed; //기본신호등 false
	public TrafficDic[] trafficDic;
	Sprite[] lights;
	TrafficType type;
	PlayerValue PV;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void OnEnable () {
		SetRandomLight();
		if (Time.time < PV.startDestroyingTime + 2){
			TrafficLightsScripts.PushUsedTraffic(gameObject);
			Debug.Log ("Destroying Seconds: " + (int)(Time.time - PV.startDestroyingTime));
		}
	}
	public void SetTypeOfTraffic(int n){
		type = (TrafficType)n;
		lights = trafficDic.First(dic => dic.type == type).sprites;
		maxIndex = lights.Length;
		isReversed = (type == TrafficType.ThreeReverse);
		SetRandomLight();
		ChangeLight();
	}
	public void SetRandomLight()
	{
		lightIndex = Random.Range(0,maxIndex);
	}

	// Update is called once per frame
	void Update () {
		if (PV.isBurning == true) {
			lightIndex = 0;
		}
		ChangeSprite ();
	}
		
	void ChangeSprite(){
		if(lightIndex >= lights.Length)
			lightIndex = 0;
		GetComponent<SpriteRenderer>().sprite = lights[lightIndex];
	}
	public void ChangeLight()
	{
		if(isReversed == false){
			lightIndex++;
			if(lightIndex >= maxIndex){
				lightIndex = 0 ;
			}
		}
		else if(isReversed == true){
			lightIndex--;
			if(lightIndex < 0){
				lightIndex = maxIndex-1 ;
			}

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (lightIndex == 0) {
				PV.itemProbability += 10;
				Debug.Log ("Item Probability: " + PV.itemProbability + "%");

				if (PV.isBurning == false) {
					PV.burningPoint += 6;
				}
				SoundManager.Play(SoundType.PassGreen);
			}
			else if (lightIndex == maxIndex - 1) {
				if (PV.policePoint < 1) {
					SoundManager.Play(MusicType.GameOver);
					SceneManager.LoadScene ("MainMenu");
					SaveBestScore ();
				} else {
					PV.policePoint -= 1;
					SoundManager.Play(SoundType.PassRedWithPolice);
					Debug.Log ("게임 오버 1회 방지");
					
				}
			}
			else {
				if (PV.itemProbability < 20) {
					PV.itemProbability = 0;
					Debug.Log ("Item Probability: " + PV.itemProbability + "%");
				} else {
					PV.itemProbability -= 20;
					Debug.Log ("Item Probability: " + PV.itemProbability + "%");
				}

				if (PV.sunglassPoint < 1) {
					if (PV.burningPoint < 24) {
						PV.burningPoint = 0;
					} else {
						PV.burningPoint -= 24;
					}
					SoundManager.Play(SoundType.PassYellow);
				} else {
					PV.sunglassPoint -= 1;
					SoundManager.Play(SoundType.PassYellowWithSunglass);
					Debug.Log ("버닝게이지 감소 1회 방지");
				}
			} 
			
		}
	}

	void SaveBestScore() {
		if (PV.score > PV.bestScore) {
			PV.bestScore = (int)PV.score;
			PlayerPrefs.SetInt ("BestScore", PV.bestScore);
		}
		PV.nextBestScore = PlayerPrefs.GetInt ("NextBestScore", 0);
		Debug.Log ("가장 멀리 간 거리: " + PV.bestScore + " / " + PV.nextBestScore);
	}
}
