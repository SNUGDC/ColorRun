using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeedData{
	static HashSet<SlowSpeedData> dataSet = new HashSet<SlowSpeedData>();
	public float speed;
	public float duration;
	public float leftTime;
	public SlowSpeedData(float s, float d){
		speed = s;
		duration = d;
		leftTime = d;
		dataSet.Add(this);
	}
	public static void ResetDataSet(){
		dataSet = new HashSet<SlowSpeedData>();
	}
	public static void ProgressLeftTime(float deltaTime){
		var deadList = new HashSet<SlowSpeedData>();
		foreach(var data in dataSet){
			data.leftTime -= deltaTime;
			if(data.leftTime <= 0){
				deadList.Add(data);
			}
		}
		foreach(var data in deadList){
			dataSet.Remove(data);
		}
	}
	public static float GetDeltaSpeed(float deltaTime){
		float deltaSpeed = 0;
		foreach(var data in dataSet){
			deltaSpeed += data.speed * deltaTime / data.duration;
		}
		return deltaSpeed;
	}
}
public class ItemSpawn : MonoBehaviour {

	static Queue<GameObject> itemPool;
	static GameObject instance;
	static GameObject standardItem;
	public int itemGeneratingIndex;
	public GameObject item;
	public Transform spawnPoint;

	PlayerValue PV;

	public static GameObject PullNewItem() {
		if (itemPool.Count > 0) {
			GameObject go = itemPool.Dequeue();
			go.transform.position = instance.GetComponent<ItemSpawn>().spawnPoint.position;
			go.SetActive(true);
			//Debug.Log("Pulled item from pool");
			return go;
		} else {
			GameObject go = Instantiate(standardItem, instance.transform);
			go.transform.position = instance.GetComponent<ItemSpawn>().spawnPoint.position;
			//Debug.Log("Created new item");
			return go;
		}
	}
	public static void PushUsedItem(GameObject go) {
		if(go.activeInHierarchy) {
			itemPool.Enqueue(go);
			go.SetActive(false);
			//Debug.Log("Pushed used item");
		}
	}

	void Awake(){
		itemPool = new Queue<GameObject>();
		instance = gameObject;
		standardItem = item;
		SlowSpeedData.ResetDataSet();
		PV = FindObjectOfType<PlayerValue>();
	}

	void Start () {
		PV.itemProbability = 0;
		
		PV.policePoint = 0;
		PV.sunglassPoint = 0;
	}
	
	void Update () {
		if(PV.isPaused) return;
		
		GameObject currentChild;
		for(int i=0; i<transform.childCount; i++)
		{
			currentChild = transform.GetChild(i).gameObject;
			ScrollItem(currentChild);
			if(currentChild.transform.position.x<=-15.0f)
			{
				PushUsedItem(currentChild);
			}
		}

		if (!PV.isBurning) SlowSpeedData.ProgressLeftTime(Time.deltaTime);
		/*
		if (Time.time < itemStartTime + duration) {
			PV.scrollSpeed += speed * Time.deltaTime / duration;
		}*/
	}
	static float itemStartTime, duration, speed;
	public static void StartTemp(float t, float d, float s){
		itemStartTime = t;
		duration = d;
		speed = s;
	}

	void ScrollItem(GameObject currentItem) {
		currentItem.transform.position -= Vector3.right * (PV.scrollSpeed * Time.deltaTime);
	}

	public void GenerateRandomItem() {
		
		itemGeneratingIndex = Random.Range (0, 100);
		if (itemGeneratingIndex < PV.itemProbability) {
			PV.itemProbability = 0;
			PullNewItem();
		}
	}
}
