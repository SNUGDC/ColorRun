using System.Collections;
using UnityEngine;

public class SoundPlayer : MonoBehaviour{
    public static float soundVolume = 1;
    public static float musicVolume = 1;
    bool isMusicPlayer = false;
    bool isSoundPlaying;
    float initTime;
    float clipLength;
    AudioSource audio;

    public void SetMusicPlayer(){
        isMusicPlayer = true;
    }
    void Awake(){
        audio = GetComponent<AudioSource>();
    }
    public void Play(AudioClip clip, bool loop = false){
        audio.Pause();
        audio.clip = clip;
        audio.Play();
        if (isMusicPlayer) audio.loop = loop;
        else SetTimer(clip.length);
    }   
    public void PlayAlone(AudioClip clip, bool loop = false){
        audio.Stop();
        audio.clip = clip;
        audio.Play();
        audio.loop = loop;
    }
    public void Stop(){
        audio.Stop();
    }
    void SetTimer(float length){
        initTime = Time.time;
        clipLength = length;
        isSoundPlaying = true;
    }
    void PushThisToPool(){
        isSoundPlaying = false;
        SoundManager.PushUsedSoundPlayer(this);
        gameObject.SetActive(false);
    }
    void Update(){
        audio.volume = isMusicPlayer? musicVolume : soundVolume;

        if(isSoundPlaying && Time.time >= initTime + clipLength){
            PushThisToPool();
        }
    }
    
    public static void SetSoundVolume(float value){
        soundVolume = value;
    }
    public static float GetSoundVolume(){
        return soundVolume;
    }
    public static void SetMusicVolume(float value){
        musicVolume = value;
    }
    public static float GetMusicVolume(){
        return musicVolume;
    }
}