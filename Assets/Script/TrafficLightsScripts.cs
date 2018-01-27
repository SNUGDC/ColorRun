using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsScripts : MonoBehaviour {

    //Traffic means Trafficlights
    public float scrollSpeed = 5.0f;
    public GameObject[] Traffic;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform TrafficSpawnPoint;

    // Use this for initialization
    void Start () {
        GenerateRandomTraffic();
	}
	
	// Update is called once per frame
	void Update () {

        //GenerateTrafficlights
        if (counter<=0.0f)
        {
            GenerateRandomTraffic();
            
        }
        else
        {
            counter -= Time.deltaTime * frequency;
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
        GameObject  newTraffic = Instantiate(Traffic[Random.Range(0, Traffic.Length)], TrafficSpawnPoint.position, Quaternion.identity) as GameObject;
        newTraffic.transform.parent = transform;
        counter = 1.0f;
    }

}
