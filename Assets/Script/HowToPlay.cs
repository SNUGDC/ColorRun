using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{

    Sprite[] sprites;
    public Image image;
    int index;

    // Use this for initialization
    void Awake(){
        sprites = Resources.LoadAll<Sprite>("HowtoPlayGame");
        Debug.Log(sprites.Length);
    }
    void OnEnable()
    {
        index = 0;
        image.sprite = sprites[index];
        Debug.Log(sprites[index].name);
    }
    public void Activate(){
        gameObject.SetActive(true);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            index++;
            if(index >= sprites.Length){
                gameObject.SetActive(false);
            } else {
                image.sprite = sprites[index];
                Debug.Log(sprites[index].name);
            }
        }
    }
}
