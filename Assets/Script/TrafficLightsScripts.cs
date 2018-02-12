using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsScripts : MonoBehaviour {

	//Traffic means Trafficlights
	public float scrollSpeed = 5.0f;
	public GameObject[] Traffic;
	public GameObject trafficLight;
	public float frequency = 0.3f;
	float counter = 0.0f;
	public Transform TrafficSpawnPoint;
	float x = 0.0f;
	float y = 1.6f;
	public float z = 0.2f;
	int n = 1;


	// Use this for initialization
	void Start () {
		GenerateRandomTraffic();

	}

	// Update is called once per frame
	void Update () {

		float k = Mathf.Log(x, y) + 5;
		if (k <= 0.0f)
		{
			scrollSpeed = 5.0f;
			frequency = 0.3f;
			x += 1 * Time.deltaTime;
		}
		else
		{
			scrollSpeed = Mathf.Log(x, y) + 5;
			frequency = Mathf.Log(scrollSpeed, 3.0f) - 1.2f;
			x += 1 * Time.deltaTime;
		}


		//GenerateTrafficlights
		z += 0.0025f * Time.deltaTime;

		if (z < 0.5)
		{
			if (counter <= Random.Range(0.0f, z))
			{
				GenerateRandomTraffic();
				n += 1;
				Debug.Log(n);

			}
			else
			{
				counter -= Time.deltaTime * frequency;
			}

		}
		else
		{
			z -= 0.1f;
		}


		//scrolling
		GameObject currentChild;
		for(int i=0; i<transform.childCount; i++)
		{
			currentChild = transform.GetChild(i).gameObject;
			ScrollTraffic(currentChild);
			if(currentChild.transform.position.x<=-15.0f)
			{
				Destroy(currentChild);
			}

		}

	}

	void ScrollTraffic(GameObject currentTraffic)
	{
		currentTraffic.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
	}

	void GenerateRandomTraffic()
	{
		GameObject  newTraffic = Instantiate(trafficLight, TrafficSpawnPoint.position, Quaternion.identity) as GameObject;
		newTraffic.transform.parent = transform;
		counter = 1.0f;
	}



}