using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLightsColor : MonoBehaviour {
	
	//public int[] lightIndex = new int[3]{0,1,2};

	//index = 0 : green
	public int lightIndex;
	public int maxIndex = 3;
	public Sprite[] lights;
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
		GetComponent<SpriteRenderer>().sprite = lights[lightIndex];
	}
	public void ChangeLight()
	{
		lightIndex++;
		if(lightIndex >= maxIndex){
			lightIndex = 0 ;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (lightIndex == 2) {
				if (PV.policePoint < 1) {
					SceneManager.LoadScene ("MainMenu");
				} else {
					PV.policePoint -= 1;
					Debug.Log ("게임 오버 1회 방지");
				}
			}

			if (lightIndex == 1) {
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
				} else {
					PV.sunglassPoint -= 1;
					Debug.Log ("버닝게이지 감소 1회 방지");
				}
			} else if (lightIndex == 0) {
				PV.itemProbability += 10;
				Debug.Log ("Item Probability: " + PV.itemProbability + "%");

				if (PV.isBurning == false) {
					PV.burningPoint += 6;
				}
			}
		}
	}
}
