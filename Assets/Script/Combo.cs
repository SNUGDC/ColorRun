using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

	public Image imageOfCombo;
	PlayerValue PV;
	public GameObject comboUIObject;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	void Start () {
		imageOfCombo.enabled = false;
		comboUIObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (PV.nowCombo >= 2) {
			imageOfCombo.enabled = true;
			comboUIObject.SetActive (true);
			comboUIObject.GetComponent<Text> ().text = PV.nowCombo.ToString();
		}

		if (PV.isCombo == false) {
			imageOfCombo.enabled = false;
			comboUIObject.SetActive (false);
		} 
	}
		
}
