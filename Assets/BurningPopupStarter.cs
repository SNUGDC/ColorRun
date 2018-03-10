using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningPopupStarter : MonoBehaviour {

	Image image;
	float initTime;
	float duration = 0.5f;
	bool isFading;

	void Awake () {
		image = GetComponent<Image>();
		isFading = false;
	}
	
	void OnEnable(){
		initTime = Time.time;
		isFading = true;
		ChangeAlpha(image, 1);
		transform.localScale = new Vector3(0,0,0);
	}
	float GetTime(){
		return Time.time - initTime;
	}
	void Update () {
		if (isFading){
			if(GetTime() < duration / 2){
				float f = (GetTime()) / (duration/2);
				f = 1 - Mathf.Cos(f * Mathf.PI/2);
				transform.localScale = new Vector3(f,f,f);
			}
			else if(GetTime() < duration){
				transform.localScale = new Vector3(1,1,1);
				ChangeAlpha(image,1);
			}
			else if(GetTime() < duration * 2){
				ChangeAlpha(image, (duration*2 - GetTime())/duration);
			}
			else{
				ChangeAlpha(image, 0);
				isFading = false;
				gameObject.SetActive(false);
			}
		}
	}
	void ChangeAlpha(Image i, float alpha){
		i.color = new Vector4 (i.color.r, i.color.g, i.color.b, alpha);
	}
}
