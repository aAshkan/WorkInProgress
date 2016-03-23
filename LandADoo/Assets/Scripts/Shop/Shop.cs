using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {
	GameObject shopSlot;
	public GameObject slotPre;
	public GameObject itemPre;

	public List<GameObject> shopSlots = new List<GameObject>();
	public List<Item> items = new List<Item>();
	// Use this for initialization
	void Start () {
		shopSlot = GameObject.Find ("Shop Panel/Shop");

		for (int a = 0; a < 3; a++) {
			//items.Add (new Item ());
			shopSlots.Add (Instantiate (slotPre)); //add slotAmount to list of slots
			//shopSlots[a].GetComponent<Slot>().id = a;
			shopSlots[a].transform.SetParent (shopSlot.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
