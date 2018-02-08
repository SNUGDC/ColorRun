using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningGauge : MonoBehaviour {

	public GameObject burningGaugeCoreUIObject;
	public Image imageOfBurningGaugeCore;
	GameObject player;
	void Start () {
		player = GameObject.Find("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		imageOfBurningGaugeCore.fillAmount = player.GetComponent<PlayerScripts> ().burningPoint / 180f;
		//burningGaugeScale = burningGaugeCoreUIObject.GetComponent<RectTransform>().transform.localScale;
		//.x= player.GetComponent<PlayerScripts> ().burningPoint
		
	}
}
