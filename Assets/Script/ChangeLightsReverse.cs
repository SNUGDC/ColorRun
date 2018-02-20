using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLightsReverse : MonoBehaviour {
	
	//public int[] lightIndex = new int[3]{0,1,2};

	//index = 0 : green
	//when clicked, trafficLight_reverse will be changed reversely : lightIndexReverse--;

	public int trafficType = 3;
	public int lightIndexReverse;
	public int maxIndexReverse = 3;
	public Sprite[] lightsReverse;
	PlayerValue PV;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		SetRandomLightReverse();
		if (Time.time < PV.startDestroyingTime + 2){
			Destroy (gameObject);
			Debug.Log ("Destroying Seconds: " + (int)(Time.time - PV.startDestroyingTime));
		}
	}
	public void SetRandomLightReverse()
	{
		lightIndexReverse = Random.Range(0,maxIndexReverse);
	}

	// Update is called once per frame
	void Update () {
		if (PV.isBurning == true) {
			lightIndexReverse = 0;
		}
		ChangeSprite ();
	}
		
	void ChangeSprite(){
		GetComponent<SpriteRenderer>().sprite = lightsReverse[lightIndexReverse];
	}
	public void ChangeLightReverse()
	{
		lightIndexReverse--;
		if(lightIndexReverse < 0){
			lightIndexReverse = maxIndexReverse-1 ;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (lightIndexReverse == 2) {
				if (PV.policePoint < 1) {
					SoundManager.Play(MusicType.GameOver);
					SceneManager.LoadScene ("MainMenu");
				} else {
					PV.policePoint -= 1;
					SoundManager.Play(SoundType.PassRedWithPolice);
					Debug.Log ("게임 오버 1회 방지");
					
				}
			}

			if (lightIndexReverse == 1) {
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
			} else if (lightIndexReverse == 0) {
				PV.itemProbability += 10;
				Debug.Log ("Item Probability: " + PV.itemProbability + "%");

				if (PV.isBurning == false) {
					PV.burningPoint += 6;
				}
				SoundManager.Play(SoundType.PassGreen);
			}
		}
	}
}
