using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

//Attached to Slot Prefab
public class BirdSlot : MonoBehaviour, IDropHandler {
	public int id;
	[SerializeField]
	private BirdInventory inv;
	[SerializeField]
	private EquippedBirdChecker birdChecker;

	// Use this for initialization
	void Start () {
		inv = GameObject.Find ("BirdInventory").GetComponent<BirdInventory> ();
		birdChecker = GameObject.Find ("Equipped Bird").GetComponent<EquippedBirdChecker> ();
	}

	//When item is dropped on a slot
	public void OnDrop(PointerEventData eventData){
		BirdData droppedItem = eventData.pointerDrag.GetComponent<BirdData> ();

		//if slot has no bird (or empty bird), set bird's id to slot's id
		if (inv.birds [id].ID == -1) {
			inv.birds [droppedItem.slot] = new Bird ();
			inv.birds [id] = droppedItem.bird;
			droppedItem.slot = id;
			if (id == 2) {
				birdChecker.equippedBird (droppedItem.bird);
			} else if (inv.birds [2].ID == -1) {
				birdChecker.equippedBird (new Bird ());
			}
		//if slot already has a bird
		} else if (droppedItem.slot != id) {
			Transform bird = this.transform.GetChild (0);
			bird.GetComponent<BirdData> ().slot = droppedItem.slot;
			bird.transform.SetParent(inv.slots[droppedItem.slot].transform);
			bird.transform.position = inv.slots[droppedItem.slot].transform.position;

			droppedItem.slot = id;
			droppedItem.transform.SetParent (this.transform);
			droppedItem.transform.position = this.transform.position;

			inv.birds [droppedItem.slot] = bird.GetComponent<BirdData> ().bird;
			inv.birds [id] = droppedItem.bird;

			if (id == 2) {
				birdChecker.equippedBird (droppedItem.bird);
			} else if (inv.birds [2].ID == -1) {
				birdChecker.equippedBird (new Bird ());
			}
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
