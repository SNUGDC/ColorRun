using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public int itemIndex;
	public Sprite police;
	public Sprite sunglass;
	public Sprite ion;
	public Sprite energy;
	public Sprite water;
	public Sprite coffee;
	public enum ItemType
	{
		police,
		sunglass,
		ion,
		energy,
		water,
		coffee
	}
	ItemType itemtype;
	private SpriteRenderer spriteRenderer;
	PlayerValue PV;
	
	void Awake(){
		PV = FindObjectOfType<PlayerValue>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	void OnEnable () {
		selectItem ();
	}

	void Update () {
	}

	void selectItem() {
		for (int i = 0; i < 100; i++){
			itemIndex = Random.Range (0, 100);
			// police
			if (0 <= itemIndex && itemIndex < 3 && PV.policePoint == 0) {
				spriteRenderer.sprite = police;
				itemtype = ItemType.police;
				//Debug.Log ("경찰 훈장: 3%");
				return;
			}
			// sunglass
			else if (3 <= itemIndex && itemIndex < 18 && PV.sunglassPoint == 0) {
				spriteRenderer.sprite = sunglass;
				itemtype = ItemType.sunglass;
				//Debug.Log ("선글라스: 15%");
				return;
			}
			// ion
			else if (18 <= itemIndex && itemIndex < 53) {
				spriteRenderer.sprite = ion;
				itemtype = ItemType.ion;
				//Debug.Log ("이온 음료: 35%");
				return;
			}
			// energy
			else if (53 <= itemIndex && itemIndex < 65) {
				spriteRenderer.sprite = energy;
				itemtype = ItemType.energy;
				//Debug.Log ("에너지 드링크: 12%");
				return;
			}
			// water
			else if (65 <= itemIndex && itemIndex < 90) {
				spriteRenderer.sprite = water;
				itemtype = ItemType.water;
				//Debug.Log ("생수: 25%");
				return;
			}
			// coffee
			else if (90 <= itemIndex && itemIndex < 100) {
				spriteRenderer.sprite = coffee;
				itemtype = ItemType.coffee;
				//Debug.Log ("커피: 10%");
				return;
			}
		}
		spriteRenderer.sprite = energy;
		itemtype = ItemType.energy;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			PV.sumGetItem += 1;
			ItemSpawn.PushUsedItem(gameObject);
			if (itemtype == ItemType.police) {
				PV.policePoint = 1;
				SoundManager.Play(SoundType.ItemEquip);
			} else if (itemtype == ItemType.sunglass) {
				PV.sunglassPoint = 1;
				SoundManager.Play(SoundType.ItemEquip);
			} else if (itemtype == ItemType.ion) {
				PV.burningPoint += 12;
				SoundManager.Play(SoundType.ItemBurning);
				Debug.Log ("버닝 포인트 12 증가");
			} else if (itemtype == ItemType.energy) {
				PV.burningPoint += 30;
				SoundManager.Play(SoundType.ItemBurning);
				Debug.Log ("버닝 포인트 30 증가");
			} else if (itemtype == ItemType.water) {
				//PV.scrollSpeed *= 0.8f;
				SoundManager.Play(SoundType.ItemSpeed);
				SlowSpeedTemp(0.8f, 3f);
			} else if (itemtype == ItemType.coffee) {
				//PV.scrollSpeed *= 0.6f; 
				SoundManager.Play(SoundType.ItemSpeed);
				//ChangeInitTime(0.0f);
				SlowSpeedTemp(0.6f, 3f);
			}
		}
	}

	void SlowSpeedTemp(float speed, float duration){
		float delta = (1 - speed) * PV.scrollSpeed;
		PV.scrollSpeed -= delta;
		//ItemSpawn.StartTemp(Time.time, duration, delta);
		new SlowSpeedData(delta, duration);
	}
	void ChangeInitTime(float f){
		float time = Time.time - PV.initTime;
		PV.initTime += (1-f)*time;
	}
}