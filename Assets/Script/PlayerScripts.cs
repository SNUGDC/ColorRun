using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	public GameObject itemsSpawn;

	void Start (){
		itemsSpawn = GameObject.Find ("ItemsSpawn");
	}

	void Update(){
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "trafficlight") {
			itemsSpawn.GetComponent<ItemSpawn>().GenerateRandomItem ();
		}
	}

}