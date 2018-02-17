using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

	public int itemGeneratingIndex;
	public GameObject item;
	public Transform itemSpawnPoint;
	public GameObject trafficLights;

	PlayerValue PV;

	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
	}
	// Use this for initialization
	void Start () {
		PV.itemProbability = 0;
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
		currentItem.transform.position -= Vector3.right * (PV.scrollSpeed * Time.deltaTime);
	}

	public void GenerateRandomItem() {
		
		itemGeneratingIndex = Random.Range (0, 100);
		if (itemGeneratingIndex < PV.itemProbability) {
			PV.itemProbability = 0;
			GameObject newItem = (GameObject)Instantiate (item, itemSpawnPoint.position, Quaternion.identity) as GameObject;
			newItem.transform.parent = transform;
		}
	}
}
