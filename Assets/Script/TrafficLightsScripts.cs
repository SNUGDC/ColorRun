using System.Collections;
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
			if (counter <= Random.Range(0.0f, z))
			{
				GenerateRandomTraffic();
				n += 1;
				//Debug.Log(n);
				//Debug.Log ("Speed: " + PV.scrollSpeed);
				PV.kmHSpeed = PV.scrollSpeed * 2;
				Debug.Log (PV.kmHSpeed + "km/h");
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
		GameObject go = PullNewTraffic();
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
}