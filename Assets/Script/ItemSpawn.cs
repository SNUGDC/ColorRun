using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

	public int itemGeneratingIndex;
	public int itemProbability;
	public GameObject item;
	public Transform itemSpawnPoint;
	public GameObject trafficLights;

	// Use this for initialization
	void Start () {
		itemProbability = 0;
		trafficLights = GameObject.Find ("TrafficLightsSpawn");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject currentChild;
		for(int i=0; i<transform.childCount; i++)
		{
			currentChild = transform.GetChild(i).gameObject;
			ScrollItem(currentChild);
			if(currentChild.transform.position.x<=-15.0f)
			{
				Destroy(currentChild);
			}

		}
	}

	void ScrollItem(GameObject currentItem) {
		currentItem.transform.position -= Vector3.right * (trafficLights.GetComponent<TrafficLightsScripts> ().scrollSpeed * Time.deltaTime);
	}

	public void GenerateRandomItem() {
		
		itemGeneratingIndex = Random.Range (0, 100);
		if (itemGeneratingIndex < itemProbability) {
			itemProbability = 0;
			GameObject newItem = (GameObject)Instantiate (item, itemSpawnPoint.position, Quaternion.identity) as GameObject;
			newItem.transform.parent = transform;
			Debug.Log ("아이템 생성");
		}
	}
}
