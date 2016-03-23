using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
	GameObject equipmentPanel;
	GameObject eSlotPanel;
	ItemDatabase database; //get database from itemdatabase.cs
	public GameObject equipmentSlot;
	public GameObject equippedItem;

	int slotAmount;
	public List<Item> equipItems = new List<Item>();
	public List<GameObject> equipSlots = new List<GameObject>();

	// Use this for initialization
	void Start () {
		database = GameObject.Find("Equipped Item").GetComponent<ItemDatabase> (); //set database
//		Debug.Log (database);
		slotAmount = 3;
		equipmentPanel = GameObject.Find ("Equipment Panel");
		eSlotPanel = equipmentPanel.transform.FindChild ("ESlot Panel").gameObject;

		for (int i = 0; i < slotAmount; i++) {
			equipItems.Add (new Item ());
			equipSlots.Add (Instantiate (equipmentSlot)); //add slotAmount to list of slots
			equipSlots[i].GetComponent<ESlot>().id = i;
			equipSlots[i].transform.SetParent (eSlotPanel.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}

		AddItem (0);
		//Debug.Log (equipItems [0]);
		//Debug.Log (database.FetchItemByID (0));
	
	}


	public void AddItem(int id) {
		Item itemToAdd = database.FetchItemByID (id);
		if (itemToAdd.Stackable && isInInventory (itemToAdd)) {
			for (int i = 0; i < equipItems.Count; i++) {
				if (equipItems [i].ID == id) {
					ItemData data = equipSlots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} else {
			for (int i = 0; i < equipItems.Count; i++) {
				if (equipItems [i].ID == -1) {
					equipItems [i] = itemToAdd;

					GameObject itemObj = Instantiate (equippedItem);
					itemObj.GetComponent<ItemData> ().item = itemToAdd;
					itemObj.GetComponent<ItemData> ().slot = i;
					itemObj.transform.SetParent (equipSlots [i].transform);
					itemObj.transform.position = equipSlots [i].transform.position;
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					ItemData data = equipSlots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					//Debug.Log (itemObj.name);
					break;
				}
			}
		}

	}

	bool isInInventory (Item item) {
		for (int i = 0; i < equipItems.Count; i++) {
			if (equipItems [i].ID == item.ID) {
				return true;
			}
		}
		return false;
	}

	int ItemCheck(Item item) {
		for (int i = 0; i < equipItems.Count; i++) {
			if (equipItems [i].ID == item.ID) {
				return i;
			}
		}
		return -1;
	}

	public void RemoveItem(int id) {
		Item itemToRemove = database.FetchItemByID (id);
		int pos = ItemCheck (itemToRemove);
		if (pos != -1) {
			if (equipItems [pos].Stackable) {
				ItemData data = equipSlots [pos].transform.GetComponentInChildren<ItemData> ();
				data.amount--;
				if (data.amount == 0) {
					equipItems [pos] = new Item ();
					Transform t = equipSlots [pos].transform.GetChild (0);
					Destroy (t.gameObject);
				} else {
					if (data.amount == 1)
						data.transform.GetComponentInChildren<Text> ().text = "";
					else
						data.transform.GetComponentInChildren<Text> ().text = data.amount.ToString ();
				}
				return;
			} else {
				equipItems[pos] = new Item();
				Transform t = equipSlots[pos].transform.GetChild(0);
				Destroy(t.gameObject);
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}


}
