using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

	public Slider soundSlider;
	public Slider musicSlider;
	public void Start(){
		soundSlider.value = SoundPlayer.GetSoundVolume();
		musicSlider.value = SoundPlayer.GetMusicVolume();
	}
    public void SetSoundVolume(){
        SoundPlayer.SetSoundVolume(soundSlider.value);
    }
	public void SetMusicVolume(){
		SoundPlayer.SetMusicVolume(musicSlider.value);	
	}
	public void EnableSetting(){
		gameObject.SetActive(true);
	}
	public void DisableSetting(){
		gameObject.SetActive(false);
	}
	public bool IsActiveInHierarchy(){
		return gameObject.activeInHierarchy;
	}
}
