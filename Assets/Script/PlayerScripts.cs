using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	public float maxBurningPoint;
	public float burningPoint;
	public float currentSpeed;
	public bool isPlayerBuring;
	Transform gaugeTf;
	Vector3 tempScale;

	void Start () {
		burningPoint = 0;
		gaugeTf = transform.Find ("BurningGaugeCore");
	}
		
	void Update () {
		tempScale = gaugeTf.localScale;
		tempScale.x = burningPoint / maxBurningPoint;
		gaugeTf.localScale = tempScale;
	}
}