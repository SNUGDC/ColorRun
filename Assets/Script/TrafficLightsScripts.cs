﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrafficLightsScripts : MonoBehaviour {

	//Traffic means Trafficlights
	static Queue<GameObject> storedTraffics;
	static GameObject instance;
	public GameObject standardTrafficLight;
	float counter = 0.0f;
	public Transform spawnPoint;
	public float z = 0.2f;
	int n = 0;
	PlayerValue PV;

	public static GameObject PullNewTraffic(int typeNum = -1) {
		if(typeNum < 0) 
			typeNum = Random.Range(0,4);

		if (storedTraffics.Count > 0) {
			var go = storedTraffics.Dequeue();
			go.GetComponent<ChangeLightsColor>().SetTypeOfTraffic(typeNum);
			go.SetActive(true);
			//Debug.Log("Pulled traffic from pool");
			return go;
		} else {
			var go = Instantiate(instance.GetComponent<TrafficLightsScripts>().standardTrafficLight, instance.transform);
			go.GetComponent<ChangeLightsColor>().SetTypeOfTraffic(typeNum);
			//Debug.Log("Created new traffic");
			return go;
		}
	}
	public static void PushUsedTraffic(GameObject go) {
		if (go.activeInHierarchy) {
			storedTraffics.Enqueue(go);
			go.SetActive(false);
			//Debug.Log("Pushed used traffic");
		}
	}

	void Awake() {	
		instance = gameObject;
		storedTraffics = new Queue<GameObject>();
		PV = FindObjectOfType<PlayerValue>();
	}
	void OnEnable() {
		PV.scrollSpeed = 3.0f;
		PV.scoreSpeed = 3f;
		PV.frequency = 0.3f;
	}
	// Use this for initialization
	void Start () {
		GenerateRandomTraffic();
		PV.scrollSpeed = 3.0f;
		PV.scoreSpeed = 3f;
		PV.frequency = 0.3f;
		PV.initTime = Time.time;
		Debug.Log("Start");

	}
	// Update is called once per frame
	void Update () {
		if(PV.isPaused) return;
		PV.nowKmHSpeed = PV.scrollSpeed * 2;
		
		GameObject currentChild;
		for(int i=0; i < spawnPoint.childCount; i++)
		{	
			currentChild = spawnPoint.GetChild(i).gameObject;
			ScrollTraffic(currentChild);
			if(currentChild.transform.position.x<=-15.0f){
				PushUsedTraffic(currentChild);
			}
		}	
		
		//GenerateTrafficlights
		z += 0.0025f * Time.deltaTime;
		if (z < 0.5)
		{
			if (counter <= Random.Range(0.0f, z) && PV.afterBurningDelay < 0.1f)
			{
				GenerateRandomTraffic();
				n += 1;
				//Debug.Log(n);
				//Debug.Log ("Speed: " + PV.scrollSpeed);
				//Debug.Log ("now: " + PV.nowKmHSpeed + "km/h // " + PV.kmHSpeed + "km/h");
			}
			else
			{
				counter -= Time.deltaTime * PV.frequency;
			}
		}
		else
		{
			z -= 0.1f;
		}
	}

	float xNow, xPast;
	void ScrollTraffic(GameObject currentTraffic)
	{
		/*xPast = xNow;
		xNow = currentTraffic.transform.position.x;
		Debug.Log("deltaX = " + (xNow-xPast) + " at " + Time.time);*/
		currentTraffic.transform.position -= Vector3.right * (PV.scrollSpeed * Time.deltaTime);
	}

	void GenerateRandomTraffic()
	{
		int randNum = ChooseTrafficByScore();
		GameObject go = PullNewTraffic(randNum);
		go.transform.SetParent(spawnPoint);
		go.transform.position = spawnPoint.position;
		counter = 1.0f;
	}

	public void ChangeColor() {
		for(int i=0; i < spawnPoint.childCount; i++)
		{	
			var currentChild = spawnPoint.GetChild(i).gameObject;
			currentChild.GetComponent<ChangeLightsColor>().ChangeLight();
		}
	}
	int ChooseTrafficByScore(){
		if (PV.score > 3000){
			return RandomGenerator(4);
		} else if (PV.score > 2000){
			return RandomGenerator(3);
		} else if (PV.score > 1000){
			return RandomGenerator(2);
		} else {
			return RandomGenerator(1);
		}
	}
	int RandomGenerator(int numOfType){
		var num = Random.value * 100;
		int value = 0;
		for (int i = 1; i < numOfType; i++){
			if (num > 100 - 25 * i) {
				//Debug.Log("RandomGenerator : " + i);
				value = i;
				break;
			}
		}
		if (value == 0) return 1;
		else if (value == 1) return 0;
		else return value;
	}
}