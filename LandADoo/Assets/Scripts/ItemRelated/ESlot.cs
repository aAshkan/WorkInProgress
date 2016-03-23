using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ESlot : MonoBehaviour {
	public int id;
	private Equipment equip;

	// Use this for initialization
	void Start () {
		equip = GameObject.Find ("Equipment").GetComponent<Equipment> ();
	}

	public void OnDrop(PointerEventData eventData){
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData> ();

		if (equip.equipItems [id].ID == -1) {
			equip.equipItems [droppedItem.slot] = new Item ();
			equip.equipItems [id] = droppedItem.item;
			droppedItem.slot = id;
		} else if (droppedItem.slot != id) {
			Transform item = this.transform.GetChild (0);
			item.GetComponent<ItemData> ().slot = droppedItem.slot;
			item.transform.SetParent(equip.equipSlots[droppedItem.slot].transform);
			item.transform.position = equip.equipSlots[droppedItem.slot].transform.position;

			droppedItem.slot = id;
			droppedItem.transform.SetParent (this.transform);
			droppedItem.transform.position = this.transform.position;

			equip.equipItems [droppedItem.slot] = item.GetComponent<ItemData> ().item;
			equip.equipItems [id] = droppedItem.item;
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
