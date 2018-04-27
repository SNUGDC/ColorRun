using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType { Main, Ingame, Challenge }
public class InputEscape : MonoBehaviour {

	public SceneType sceneType;
	public SettingMenu setting;
	public GoToOtherScene sceneMover;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (sceneType == SceneType.Main){
				if (setting != null && setting.IsActiveInHierarchy()){
					setting.DisableSetting(); return;
				}
				Application.Quit(); return;
			}
			if (sceneType == SceneType.Challenge){
				sceneMover.GoToMainMenu(); return;
			}
		}		
	}
}
