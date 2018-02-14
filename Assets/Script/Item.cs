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
	public GameObject player;

		
	void Start () {
		player = GameObject.Find ("Player");
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		itemIndex = Random.Range (0, 100);
		selectItem ();
	}

	void Update () {
	}

	void selectItem() {
		// police
		if (0 <= itemIndex && itemIndex < 3) {
			spriteRenderer.sprite = police;
			itemtype = ItemType.police;
			Debug.Log ("경찰 훈장: 3%");
		}
		// sunglass
		else if (3 <= itemIndex && itemIndex < 18) {
			spriteRenderer.sprite = sunglass;
			itemtype = ItemType.sunglass;
			Debug.Log ("선글라스: 15%");
		}
		// ion
		else if (18 <= itemIndex && itemIndex < 53) {
			spriteRenderer.sprite = ion;
			itemtype = ItemType.ion;
			Debug.Log ("이온 음료: 35%");
		}
		// energy
		else if (53 <= itemIndex && itemIndex < 65) {
			spriteRenderer.sprite = energy;
			itemtype = ItemType.energy;
			Debug.Log ("에너지 드링크: 12%");
		}
		// water
		else if (65 <= itemIndex && itemIndex < 90) {
			spriteRenderer.sprite = water;
			itemtype = ItemType.water;
			Debug.Log ("생수: 25%");
		}
		// coffee
		else if (90 <= itemIndex && itemIndex < 100) {
			spriteRenderer.sprite = coffee;
			itemtype = ItemType.coffee;
			Debug.Log ("커피: 10%");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (itemtype == ItemType.police) {
			
			} else if (itemtype == ItemType.sunglass) {

			} else if (itemtype == ItemType.ion) {

			} else if (itemtype == ItemType.energy) {

			} else if (itemtype == ItemType.water) {

			} else if (itemtype == ItemType.coffee) {

			}
		}
	}
}