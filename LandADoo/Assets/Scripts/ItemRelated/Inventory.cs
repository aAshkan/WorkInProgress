using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	private GameObject inventoryPanel;
	private GameObject invPanel;
	private GameObject slotPanel;
	private GameObject equipPanel;
	private ItemDatabase database; //get database from itemdatabase.cs
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start() {
		database = GameObject.Find("Equipped Item").GetComponent<ItemDatabase> (); //set database
		slotAmount = 3 + database.returnDatabaseSize();
		inventoryPanel = GameObject.Find ("Inventory Panel");
		//invPanel = inventoryPanel.transform.FindChild ("Inv Panel").gameObject;
		slotPanel = inventoryPanel.transform.FindChild ("Slot Panel").gameObject;
		equipPanel = inventoryPanel.transform.FindChild ("Equip Panel").gameObject;

		for (int a = 0; a < 3; a++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot)); //add slotAmount to list of slots
			slots[a].GetComponent<Slot>().id = a;
			slots[a].transform.SetParent (equipPanel.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}

		for (int i = 3; i < slotAmount; i++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot)); //add slotAmount to list of slots
			slots[i].GetComponent<Slot>().id = i;
			slots[i].transform.SetParent (slotPanel.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}


		//Debug.Log (database.FetchItemByID (0));
		if (database.returnDatabaseSize() >= 1) {
			for (int b = 0; b < database.returnDatabaseSize (); b++) {
				Debug.Log ("AddItem");
				AddItem (b);
				Debug.Log (database.returnDatabaseSize ());
			}
		}

	}

	public void AddItem(int id) {
		Item itemToAdd = database.FetchItemByID (id);
		/*if (itemToAdd.Stackable && isInInventory (itemToAdd)) {
			for (int i = 3; i < items.Count; i++) { 
				if (items [i].ID == id) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} else {*/
		for (int i = 3; i < items.Count; i++) {
			if (items [i].ID == -1) {
				items [i] = itemToAdd;

				//Debug.Log (itemToAdd.Title);
				//Debug.Log (itemToAdd.Location);
				GameObject itemObj = Instantiate (inventoryItem);
				itemObj.GetComponent<ItemData> ().item = itemToAdd;
				itemObj.GetComponent<ItemData> ().slot = i;
				itemObj.transform.SetParent (slots [i].transform);
				itemObj.transform.position = slots [i].transform.position;
				itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
				itemObj.name = itemToAdd.Title;
				ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
				data.amount++;
				//Debug.Log (itemObj.name);
				break;
			}
		}
	}
	bool isInInventory (Item item) {
		for (int i = 0; i < items.Count; i++) {
			if (items [i].ID == item.ID) {
				return true;
			}
		}
		return false;
	}


	int ItemCheck(Item item) {
		for (int i = 0; i < items.Count; i++) {
			if (items [i].ID == item.ID) {
				return i;
			}
		}
		return -1;
	}

	public void RemoveItem(int id) {
		Item itemToRemove = database.FetchItemByID (id);
		int pos = ItemCheck (itemToRemove);
		if (pos != -1) {
			if (items [pos].Stackable) {
				ItemData data = slots [pos].transform.GetComponentInChildren<ItemData> ();
				data.amount--;
				if (data.amount == 0) {
					items [pos] = new Item ();
					Transform t = slots [pos].transform.GetChild (0);
					Destroy (t.gameObject);
				} else {
					if (data.amount == 1)
						data.transform.GetComponentInChildren<Text> ().text = "";
					else
						data.transform.GetComponentInChildren<Text> ().text = data.amount.ToString ();
				}
				return;
			} else {
				items[pos] = new Item();
				Transform t = slots[pos].transform.GetChild(0);
				Destroy(t.gameObject);
			}
		}
	}
}
