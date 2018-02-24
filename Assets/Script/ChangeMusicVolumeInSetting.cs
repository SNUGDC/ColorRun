using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolumeInSetting : MonoBehaviour {

    // Use this for initialization

    public Slider Volume;
    public AudioSource myMusic;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myMusic.volume = Volume.value;

    }
}
