using System.Collections;
using UnityEngine;

public class PlayerValue : MonoBehaviour
{
    public float scrollSpeed;
    public float scoreSpeed;
    public float frequency;

    public float burningPoint;
    public bool isBurning;
    public bool isReadyForBurning;
    public float startDestroyingTime;
    public float savedScrollSpeed;
    public float savedScoreSpeed;
    public float alphaSpeed;

    public int itemProbability;
    public float initTime;
    public int policePoint;
    public int sunglassPoint;
    public int colorOfPlayer;
    public bool isPaused;

	public float score;

	public int bestScore;
	public int nextBestScore;
	public int sumScore;
	public int nextSumScore;
	public int totalGreenLights;
	public int nextTotalGreenLights;
	public bool isCombo;
	public int nowCombo;
	public int combo;
	public int comboGreenLight;
	public int nextComboGreenLight;
}