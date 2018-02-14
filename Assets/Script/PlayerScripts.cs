using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	public GameObject itemsSpawn;
	public int policePoint;
	public int sunglassPoint;

	void Start (){
		itemsSpawn = GameObject.Find ("ItemsSpawn");
		policePoint = 0;
		sunglassPoint = 0;
	}

	void Update(){
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "trafficlight") {
			itemsSpawn.GetComponent<ItemSpawn>().GenerateRandomItem ();
		}
	}

}