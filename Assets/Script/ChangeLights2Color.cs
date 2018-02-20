using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLights2Color : MonoBehaviour {
	
	//public int[] lightIndex = new int[2]{0,1};

	//index = 0 : green
	public int trafficType = 2;
	public int lightIndexOf2Colors;
	public int maxIndexOf2Colors = 2;
	public Sprite[] lightsOf2Colors;
	PlayerValue PV;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		SetRandomLightOf2Colors();
		if (Time.time < PV.startDestroyingTime + 2){
			Destroy (gameObject);
			Debug.Log ("Destroying Seconds: " + (int)(Time.time - PV.startDestroyingTime));
		}
	}
	public void SetRandomLightOf2Colors()
	{
		lightIndexOf2Colors = Random.Range(0,maxIndexOf2Colors);
	}

	// Update is called once per frame
	void Update () {
		if (PV.isBurning == true) {
			lightIndexOf2Colors = 0;
		}
		ChangeSprite();
	}
		
	void ChangeSprite(){
		GetComponent<SpriteRenderer>().sprite = lightsOf2Colors[lightIndexOf2Colors];
	}
	public void ChangeLightOf2Colors()
	{
		lightIndexOf2Colors++;
		if(lightIndexOf2Colors >= maxIndexOf2Colors){
			lightIndexOf2Colors = 0 ;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (lightIndexOf2Colors == 2) {
				if (PV.policePoint < 1) {
					SoundManager.Play(MusicType.GameOver);
					SceneManager.LoadScene ("MainMenu");
				} else {
					PV.policePoint -= 1;
					SoundManager.Play(SoundType.PassRedWithPolice);
					Debug.Log ("게임 오버 1회 방지");
					
				}
			}
        else if (lightIndexOf2Colors == 0) {
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
