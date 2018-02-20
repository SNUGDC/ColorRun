using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrafficLightsScripts : MonoBehaviour {

	//Traffic means Trafficlights
	Queue<GameObject> storedTraffics = new Queue<GameObject>();
	public GameObject trafficLight_0;
	public GameObject trafficLight_1;
	public GameObject trafficLight_2;
	public GameObject trafficLight_3;
	float counter = 0.0f;
	public Transform TrafficSpawnPoint;
	float logBase = 1.6f;
	public float z = 0.2f;
	int n = 0;
	float scoreTime;
	PlayerValue PV;

	void Awake()
	{	
		PV = FindObjectOfType<PlayerValue>();
	}
	void OnEnable()
	{
		PV.scrollSpeed = 3.0f;
		PV.scoreSpeed = 3f;
		PV.frequency = 0.3f;
	}
	// Use this for initialization
	void Start () {
			int randTrafficIndex=0;
		for (int i = 0; i < 15; i++)
		{	//randTrafficIndex = Random.Range(0,4); // 0: 3색, 1: 4색, 2: 2색, 3: 거꾸로
			if(randTrafficIndex == 0){
				var go = Instantiate(trafficLight_0, transform);
				storedTraffics.Enqueue(go);
				go.SetActive(false);
			}
		}
		GenerateRandomTraffic();
		PV.scrollSpeed = 3.0f;
		PV.scoreSpeed = 3f;
		PV.frequency = 0.3f;
		PV.initTime = Time.time;
		scoreTime = Time.time;
		Debug.Log("Start");
	}
	float GetTime()
	{
		return Time.time - PV.initTime;
	}
	// Update is called once per frame
	void Update () {
		
		if (GetTime() <= 1.0f)
		{
			
		}
		else
		{
			PV.scrollSpeed += Mathf.Log(2.718281f, logBase) * Time.deltaTime / GetTime() + PV.alphaSpeed*Time.deltaTime;
			PV.scoreSpeed += Mathf.Log(2.718281f, logBase) * Time.deltaTime / (Time.time - scoreTime) + PV.alphaSpeed*Time.deltaTime;
			PV.frequency = PV.scrollSpeed/20 * (GetTime()/60 + 1);
		}


		//GenerateTrafficlights
		z += 0.0025f * Time.deltaTime;

		if (z < 0.5)
		{
			if (counter <= Random.Range(0.0f, z))
			{
				GenerateRandomTraffic();
				n += 1;
				//Debug.Log(n);
				Debug.Log ("Speed: " + PV.scrollSpeed);
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


		
		GameObject currentChild;

		for(int i=0; i < TrafficSpawnPoint.childCount; i++)
		{	currentChild = TrafficSpawnPoint.GetChild(i).gameObject;
			
			ScrollTraffic(currentChild);
			if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
				currentChild.GetComponent<ChangeLightsColor>().ChangeLight();
				/*
				currentChild.GetComponent<ChangeLights4Color>().ChangeLightOf4Colors();
				currentChild.GetComponent<ChangeLights2Color>().ChangeLightOf2Colors();
				currentChild.GetComponent<ChangeLightsReverse>().ChangeLightReverse();
				*/
			}
			if(currentChild.transform.position.x<=-15.0f){
				storedTraffics.Enqueue(currentChild);
				currentChild.GetComponent<ChangeLightsColor>().SetRandomLight();
				/*
				currentChild.GetComponent<ChangeLights4Color>().SetRandomLightOf4Colors();
				currentChild.GetComponent<ChangeLights2Color>().SetRandomLightOf2Colors();
				currentChild.GetComponent<ChangeLightsReverse>().SetRandomLightReverse();
				*/
				currentChild.transform.SetParent(transform);
				currentChild.SetActive(false);
			}

		}

	}

	void ScrollTraffic(GameObject currentTraffic)
	{
		currentTraffic.transform.position -= Vector3.right * (PV.scrollSpeed * Time.deltaTime);
	}

	void GenerateRandomTraffic()
	{
		var go = storedTraffics.Dequeue();
		go.transform.SetParent(TrafficSpawnPoint);
		go.transform.position = TrafficSpawnPoint.position;
		go.SetActive(true);
		counter = 1.0f;
	}
}