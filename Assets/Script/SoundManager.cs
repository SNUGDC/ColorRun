 using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SoundType { ChangeLight, PassGreen, PassYellow, PassYellowWithSunglass, PassRedWithPolice,
    BurningIntro, BurningStatus, BurningChangeLight, ItemEquip, ItemSpeed, ItemBurning }
public enum MusicType { Main, Ingame, GameOver }

[System.Serializable]
public class SoundDic{
    public SoundType type;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour{
    static SoundManager instance;
    static Queue<SoundPlayer> spPool;
    static SoundPlayer musicPlayer;
    static SoundPlayer burningPlayer;
    
    public GameObject standardSoundPlayer;
    public SoundDic[] soundDictionary;
    public AudioClip[] musicDictionary;
    static SoundPlayer GetSoundPlayer(){
        if (spPool.Count > 0) {
            SoundPlayer sp = spPool.Dequeue();
            sp.gameObject.SetActive(true);
            return sp;
        } else {
            GameObject go = Instantiate(instance.standardSoundPlayer, instance.gameObject.transform);
            return go.GetComponent<SoundPlayer>();
        }
    }
    public static void PushUsedSoundPlayer(SoundPlayer sp) { 
        spPool.Enqueue(sp);
    }

    public void PlayNonStatic(SoundType st){
        SoundManager.Play(st);
    }
    public static void Play(SoundType st){
        var selectedDics = instance.soundDictionary.Where(sd => sd.type == st).ToArray();
        var clip = selectedDics[Random.Range(0,selectedDics.Length)].clip;
        GetSoundPlayer().Play(clip);
    }
    public static void Play(MusicType mt){
        int n;
        bool loop = true;
        switch(mt){
            case MusicType.Main:        n = 0;                  break;
            case MusicType.Ingame:      n = 1;                  break;
            case MusicType.GameOver:    n = 2; loop = false;    break;
            default:                    n = 0;                  break;
        }
        var clip = instance.musicDictionary[n];
        musicPlayer.Play(clip, loop);
    }
    public static void PlayBurning(){
        var selectedDics = instance.soundDictionary.Where(sd => sd.type == SoundType.BurningStatus).ToArray();
        var clip = selectedDics[Random.Range(0,selectedDics.Length)].clip;
        burningPlayer.PlayAlone(clip);
    }
    public static void StopBurning(){
        burningPlayer.Stop();
    }
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            spPool = new Queue<SoundPlayer>();
            var musicPlayerGO = Instantiate(instance.standardSoundPlayer, instance.gameObject.transform);
            musicPlayer = musicPlayerGO.GetComponent<SoundPlayer>();
            musicPlayer.SetMusicPlayer();
            var burningPlayerGO = Instantiate(instance.standardSoundPlayer, instance.gameObject.transform);
            burningPlayer = burningPlayerGO.GetComponent<SoundPlayer>();
            DontDestroyOnLoad(instance);

            if(FindObjectOfType<PlayerScripts>()) Play(MusicType.Ingame);
            else Play(MusicType.Main);
        }
    }
}