using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {
	public int id;
	private Inventory inv;
	private EquipChecker itemChecker;

	//private Equipment equip;

	// Use this for initialization
	void Start () {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		itemChecker = GameObject.Find ("Equipped Item").GetComponent<EquipChecker> ();
	
	//	equip = GameObject.Find ("Equipment").GetComponent<Equipment> ();
	}

	public void OnDrop(PointerEventData eventData){
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData> ();

		if (inv.items [id].ID == -1) {
			inv.items [droppedItem.slot] = new Item ();
			inv.items [id] = droppedItem.item;
			droppedItem.slot = id;

			if (id == 0) {
				itemChecker.equippedItemOne (droppedItem.item);
			} else if (inv.items [0].ID == -1) {
				itemChecker.equippedItemOne (new Item ());
			}

			if (id == 1) {
				itemChecker.equippedItemTwo (droppedItem.item);
			}  else if (inv.items [1].ID == -1) {
				itemChecker.equippedItemOne (new Item ());
			}

			if (id == 2) {
				itemChecker.equippedItemThree (droppedItem.item);
			}  else if (inv.items [2].ID == -1) {
				itemChecker.equippedItemOne (new Item ());
			}


		} else if (droppedItem.slot != id) {
			Transform item = this.transform.GetChild (0);
			item.GetComponent<ItemData> ().slot = droppedItem.slot;
			item.transform.SetParent(inv.slots[droppedItem.slot].transform);
			item.transform.position = inv.slots[droppedItem.slot].transform.position;

			droppedItem.slot = id;
			droppedItem.transform.SetParent (this.transform);
			droppedItem.transform.position = this.transform.position;

			inv.items [droppedItem.slot] = item.GetComponent<ItemData> ().item;
			inv.items [id] = droppedItem.item;

			if (id == 0) {
				itemChecker.equippedItemOne (droppedItem.item);
			} else if (inv.items [0].ID == -1) {
				itemChecker.equippedItemOne (new Item ());
			}

			if (id == 1) {
				itemChecker.equippedItemTwo (droppedItem.item);
			}  else if (inv.items [1].ID == -1) {
				itemChecker.equippedItemOne (new Item ());
			}

			if (id == 2) {
				itemChecker.equippedItemThree (droppedItem.item);
			}  else if (inv.items [2].ID == -1) {
				itemChecker.equippedItemOne (new Item ());
			}

		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
