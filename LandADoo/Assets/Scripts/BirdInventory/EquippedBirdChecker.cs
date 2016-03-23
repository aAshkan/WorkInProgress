using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//this file remembers which bird is equipped
public class EquippedBirdChecker : MonoBehaviour {
	public static EquippedBirdChecker Instance;
	public static Bird bird = new Bird();

	//is called whenever a bird is placed on equip slot
	public void equippedBird (Bird b) {
		bird = b;
		Debug.Log (bird.Title);
		Debug.Log (bird.ID);
	}

	public Bird returnBird() {
		return bird;
	}

	public bool hasBird () {
		if (bird.ID == -1) {
			return false;
		}
		return true;
	}
	//this will be remembered;
	void Awake() {

		if (Instance) {
			DestroyImmediate (gameObject);
		}
		else{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		//DontDestroyOnLoad (this);
	}

	/*public int birdID;
	private GameObject equipPanel;
	private GameObject slotOne;
	private GameObject firstBird;
	private BirdDatabase database;
	private Bird bird;
	private List <Bird> equippedBird = new List <Bird>();

	void Awake() {
		//DontDestroyOnLoad (this);
	}
	// Use this for initialization
	void Start () {
		birdID = -1;
		equipPanel =  GameObject.Find ("Inventory Panel/Equip Panel");
		slotOne = equipPanel.transform.GetChild (0).gameObject;
		//inv = GameObject.Find ("BirdInventory").GetComponent<BirdInventory> ();
		database = GameObject.Find ("BirdInventory").GetComponent<BirdDatabase> ();
		Debug.Log (birdID);
	}

	// Update is called once per frame
	void Update () {
		if (slotOne.transform.childCount > 0) {
			firstBird = slotOne.transform.GetChild (0).gameObject;
			bird = firstBird.GetComponent<BirdData> ().bird;
			if (birdID == bird.ID) {
				return;
			} else {
				birdID = bird.ID;
				//Debug.Log (birdID);
			}
			return;
		} else {
			birdID = -1;
			//Debug.Log (birdID);
			return;
		}
		//} else {
			//return;
		//}
	
	}*/
}
