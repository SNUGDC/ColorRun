using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrafficLightsScripts : MonoBehaviour {

	//Traffic means Trafficlights
	Queue<GameObject> storedTraffics = new Queue<GameObject>();
	public GameObject trafficLight;
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

		for (int i = 0; i < 10; i++)
		{
			var go = Instantiate(trafficLight, transform);
			storedTraffics.Enqueue(go);
			go.SetActive(false);
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
		{
			currentChild = TrafficSpawnPoint.GetChild(i).gameObject;
			ScrollTraffic(currentChild);
			if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
				currentChild.GetComponent<ChangeLightsColor>().ChangeLight();
			}
			if(currentChild.transform.position.x<=-15.0f){
				storedTraffics.Enqueue(currentChild);
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