using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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
        if (PV.colorOfPlayer == 2)
        {
            PV.life = 1;
        }
        else
        {
            PV.life = 0;
        }
    }
	void OnEnable () {
		SetRandomLight();
		if (Time.time < PV.startDestroyingTime + 2){
			TrafficLightsScripts.PushUsedTraffic(gameObject);
			//Debug.Log ("Destroying Seconds: " + (int)(Time.time - PV.startDestroyingTime));
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
		if (PV.isBurning == true || PV.afterBurningDelay > 0.5) {
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
			if (lightIndex == 0 ) {
				//Debug.Log ("Item Probability: " + PV.itemProbability + "%");
				if(PV.afterBurningDelay < 0f){
					PV.itemProbability += 10;
				}
				if (PV.isBurning == false) {

                    if (PV.colorOfPlayer == 0)
                    {
                        PV.burningPoint += 7.5f;

                    }else
                    {
                        PV.burningPoint += 6;
                    }
					
				}
				SoundManager.Play(SoundType.PassGreen);

				PV.totalGreenLights += 1;
				CheckCombo ();
                Debug.Log(PV.nowCombo);
				if (PV.nowKmHSpeed > PV.kmHSpeed) {
					PV.kmHSpeed = PV.nowKmHSpeed;
				}
			}
			else if (lightIndex == maxIndex - 1) {
				if (PV.nowCombo > PV.combo) {
					PV.combo = PV.nowCombo;
				}
				PV.nowCombo = 0;
				//Debug.Log ("COMBO: " + PV.nowCombo + " " + PV.isCombo);
				PV.isCombo = false;

				if (PV.nowKmHSpeed > PV.kmHSpeed) {
					PV.kmHSpeed = PV.nowKmHSpeed;
				}

				if (PV.policePoint < 1) {
                    if (PV.life == 1)
                    {
                        PV.life -= 1;
                        Debug.Log("life is null");
                        SoundManager.Play(SoundType.PassRedWithPolice);
                    } else {
                        SoundManager.Play(MusicType.GameOver);
                        PV.isGameOvered = true;
                        //SceneManager.LoadScene ("MainMenu");
                        //게임오버함수 호출 작성해야함
                        SaveScore();
                    }
                } else {
					PV.policePoint -= 1;
					SoundManager.Play(SoundType.PassRedWithPolice);
					//Debug.Log ("게임 오버 1회 방지");
					
				}
			}
			else {
				if (PV.nowCombo > PV.combo) {
					PV.combo = PV.nowCombo;
				}
				
				if (!(PV.colorOfPlayer == 1 && PV.nowCombo <= 70 )){
					PV.nowCombo = 0;
					//Debug.Log ("COMBO: " + PV.nowCombo + " " + PV.isCombo);
					PV.isCombo = false;
				}

				if (PV.nowKmHSpeed > PV.kmHSpeed) {
					PV.kmHSpeed = PV.nowKmHSpeed;
				}

				if (PV.itemProbability < 20) {
					PV.itemProbability = 0;
					//Debug.Log ("Item Probability: " + PV.itemProbability + "%");
				} else {
					PV.itemProbability -= 20;
					//Debug.Log ("Item Probability: " + PV.itemProbability + "%");
				}

				if (PV.sunglassPoint < 1) {

                    if (PV.colorOfPlayer == 1)
                    {
                        if (PV.burningPoint < 12)
                        {
                            PV.burningPoint = 0;
                        }
                        else
                        {
                            PV.burningPoint -= 12;
                        }
                    }
                    else
                    {
                        if (PV.burningPoint < 24)
                        {
                            PV.burningPoint = 0;
                        }
                        else
                        {
                            PV.burningPoint -= 24;
                        }
                    }
					SoundManager.Play(SoundType.PassYellow);
				} else {
					PV.sunglassPoint -= 1;
					SoundManager.Play(SoundType.PassYellowWithSunglass);
					//Debug.Log ("버닝게이지 감소 1회 방지");
				}
			}
			
		}
	}

	void CheckCombo(){
		if (PV.isCombo == true) {
			PV.nowCombo += 1;
			if (PV.nowCombo == 1) {
				PV.nowCombo += 1;
			}
		}
		//Debug.Log ("COMBO: " + PV.nowCombo + " " + PV.isCombo);
		PV.isCombo = true;

		if (PV.nowCombo > PV.combo) {
			PV.combo = PV.nowCombo;
		}
	}

	void SaveScore() {
		if (PV.score > PV.bestScore) {
			PV.bestScore = (int)PV.score;
			PlayerPrefs.SetInt ("BestScore", PV.bestScore);
		}

		PV.sumScore += (int)PV.score;
		PlayerPrefs.SetInt ("SumScore", PV.sumScore);

		PlayerPrefs.SetInt ("TotalGreenLights", PV.totalGreenLights);

		if (PV.combo > PV.comboGreenLight) {
			PV.comboGreenLight = PV.combo;
			PlayerPrefs.SetInt ("ComboGreenLight", PV.comboGreenLight);
		}

		PV.sumBurningCount += PV.burningCount;
		PlayerPrefs.SetInt ("SumBurningCount", PV.sumBurningCount);

		PlayerPrefs.SetInt ("SumGetItem", PV.sumGetItem);

		if (PV.kmHSpeed > PV.bestSpeed) {
			PV.bestSpeed = PV.kmHSpeed;
			PV.bestSpeed = Mathf.Floor (PV.kmHSpeed * 10) * 0.1f;
			PlayerPrefs.SetFloat ("BestSpeed", PV.bestSpeed);
		}


		PlayerPrefs.SetInt ("TotalTouch", PV.totalTouch);

		PV.nextSumScore = PlayerPrefs.GetInt ("NextSumScore", 0);
		PV.nextBestScore = PlayerPrefs.GetInt ("NextBestScore", 0);
		PV.nextTotalGreenLights = PlayerPrefs.GetInt ("NextTotalGreenLights", 0);
		PV.nextComboGreenLight = PlayerPrefs.GetInt ("NextComboGreenLight", 0);
		PV.nextSumBurningCount = PlayerPrefs.GetInt ("NextSumBurningCount", 0);
		PV.nextSumGetItem = PlayerPrefs.GetInt ("NextSumGetItem", 0);
		PV.nextBestSpeed = PlayerPrefs.GetFloat ("NextBestSpeed", 0);
		PV.nextTotalTouch = PlayerPrefs.GetInt ("NextTotalTouch", 0);
		//Debug.Log ("총 달린 거리: " + PV.sumScore + " / " + PV.nextSumScore);
		//Debug.Log ("가장 멀리 간 거리: " + PV.bestScore + " / " + PV.nextBestScore);
		//Debug.Log ("총 초록불 통과 개수: " + PV.totalGreenLights + " / " + PV.nextTotalGreenLights);
		//Debug.Log ("초록불 최고 연속 통과 개수: " + PV.comboGreenLight + " / " + PV.nextComboGreenLight);
		//Debug.Log ("버닝상태 진입 횟수: " + PV.sumBurningCount + " / " + PV.nextSumBurningCount);
		//Debug.Log ("지금까지 획득한 아이템 개수: " + PV.sumGetItem + " / " + PV.nextSumGetItem);
		//Debug.Log ("최고 속도: " + PV.bestSpeed + " / " + PV.nextBestSpeed);
		//Debug.Log ("지금까지 터치한 횟수: " + PV.totalTouch + " / " + PV.nextTotalTouch);
	}
}
