﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOtherScene : MonoBehaviour {


	public void GoToMainMenu() {
		SceneManager.LoadScene("MainMenu");
		SoundManager.Play(MusicType.Main);
	}
	public void GoToLoadingScene() {
		SceneManager.LoadScene ("Loading");
	}
	public void GoToSetUp() {
		SceneManager.LoadScene ("SetUp");
	}
	public void GoToGameOverScene() {
		SceneManager.LoadScene ("GameOver");
	}

    public void GoToChallengeScen()
    {
        SceneManager.LoadScene("Challenge");
    }
	
    public void GoToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }


}
