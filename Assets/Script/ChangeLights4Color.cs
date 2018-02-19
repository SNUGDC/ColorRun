using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLights4Color : MonoBehaviour {
	
	//public int[] lightIndex = new int[4]{0,1,2,3};

	//index = 0 : green
	public int lightIndexOf4Colors;
	public int maxIndexOf4Colors = 4;
	public Sprite[] lightsOf4Colors;
	PlayerValue PV;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		SetRandomLight();
		if (Time.time < PV.startDestroyingTime + 2){
			Destroy (gameObject);
			Debug.Log ("Destroying Seconds: " + (int)(Time.time - PV.startDestroyingTime));
		}
	}
	public void SetRandomLight()
	{
		lightIndexOf4Colors = Random.Range(0,maxIndexOf4Colors);
	}

	// Update is called once per frame
	void Update () {
		if (PV.isBurning == true) {
			lightIndexOf4Colors = 0;
		}
		ChangeSprite ();
	}
		
	void ChangeSprite(){
		GetComponent<SpriteRenderer>().sprite = lightsOf4Colors[lightIndexOf4Colors];
	}
	public void ChangeLight()
	{
		lightIndexOf4Colors++;
		if(lightIndexOf4Colors >= maxIndexOf4Colors){
			lightIndexOf4Colors = 0 ;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (lightIndexOf4Colors == 3) {
				if (PV.policePoint < 1) {
					SoundManager.Play(MusicType.GameOver);
					SceneManager.LoadScene ("MainMenu");
				} else {
					PV.policePoint -= 1;
					SoundManager.Play(SoundType.PassRedWithPolice);
					Debug.Log ("게임 오버 1회 방지");
					
				}
			}

			if (lightIndexOf4Colors == 2) {
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
			} else if (lightIndexOf4Colors == 0) {
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
