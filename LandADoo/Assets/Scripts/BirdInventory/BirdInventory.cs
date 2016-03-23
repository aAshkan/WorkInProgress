using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BirdInventory : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
	GameObject equipPanel;
	GameObject breedPanel;
	private BirdDatabase database; //get database from birddatabase.cs
	public GameObject inventorySlot;
	public GameObject inventoryBird;


	int slotAmount;
	public List<Bird> birds = new List<Bird>();
	public List<GameObject> slots = new List <GameObject> ();

	void Start() {

		database = GetComponent<BirdDatabase> (); //get database
		slotAmount = 3 + database.returnDatabaseSize ();
		inventoryPanel = GameObject.Find ("Inventory Panel");
		slotPanel = inventoryPanel.transform.FindChild ("Inventory Slots/ScrollRect").gameObject;
		equipPanel = inventoryPanel.transform.FindChild ("Equip Panel").gameObject;
		breedPanel = inventoryPanel.transform.FindChild ("Breed Panel").gameObject;

		//add 2 breeding slots
		for (int a = 0; a < 2; a++) {
			birds.Add (new Bird ()); // each slot contains a bird with an ID of -1 and w.o any info/stats
			slots.Add (Instantiate (inventorySlot)); //add slotAmount to list of slots
			slots[a].GetComponent<BirdSlot>().id = a;
			slots[a].transform.SetParent (breedPanel.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}

		//add an equip slot
		for (int a = 2; a < 3; a++) {
			birds.Add (new Bird ());
			slots.Add (Instantiate (inventorySlot)); //add slotAmount to list of slots
			slots[a].GetComponent<BirdSlot>().id = a;
			slots[a].transform.SetParent (equipPanel.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}

		//add inventory slots
		for (int i = 3; i < slotAmount; i++) {
			birds.Add (new Bird ());
			slots.Add (Instantiate (inventorySlot)); //add slotAmount to list of slots
			slots[i].GetComponent<BirdSlot>().id = i;
			slots[i].transform.SetParent (slotPanel.transform); //set slot as child of slot panel, so that slot will follow slotpanel
		}

		//add all birds from database to inventory
		for (int b = 0; b < database.returnDatabaseSize(); b++) {
			AddItem (b);
			//Debug.Log ("database size " + b);
		}

		Debug.Log ("hello2");

	}

	//add items to in inventory
	public void AddItem(int id) {
		Bird birdToAdd = database.FetchBirdByID (id); //find bird's ID
		//Debug.Log (database.FetchBirdByID (id));

		//starting from slot/bird 3 
		for (int i = 3; i < birds.Count; i++) { 
			if (birds [i].ID == -1) { //add only if slot has a bird with no stats or info
				birds [i] = birdToAdd;
				GameObject birdObj = Instantiate (inventoryBird);

				//bird's prefab contains a "BirdData" script file that contain all of its info
				birdObj.GetComponent<BirdData> ().bird = birdToAdd;
				birdObj.GetComponent<BirdData> ().slot = i;
				birdObj.transform.SetParent (slots [i].transform);
				birdObj.transform.position = slots [i].transform.position;

				//set its sprite 
				birdObj.transform.FindChild ("Eye").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.EyeSlug];
				birdObj.transform.FindChild ("Blush").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.BlushSlug];
				birdObj.transform.FindChild ("Body").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.BodySlug];
				birdObj.transform.FindChild ("WingFront").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.WingFrontSlug];
				birdObj.transform.FindChild ("WingBack").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.WingBackSlug];
				birdObj.transform.FindChild ("Beak").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.BeakSlug];
				birdObj.transform.FindChild ("LegFront").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.LegFrontSlug];
				birdObj.transform.FindChild ("LegBack").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.LegBackSlug];
				birdObj.transform.FindChild ("Tail").GetComponent<Image> ().sprite = database.dictSprites[birdToAdd.TailSlug];

				//set its location
				birdObj.transform.FindChild ("Eye").transform.position = new Vector2 (25f, 13f);
				birdObj.transform.FindChild ("Blush").transform.position = new Vector2 (21f, 3f);
				birdObj.transform.FindChild ("Body").transform.position = new Vector2 (4f, 0f);
				birdObj.transform.FindChild ("WingFront").transform.position = new Vector2 (-12f,8f);
				birdObj.transform.FindChild ("WingBack").transform.position = new Vector2 (3f,6f);
				birdObj.transform.FindChild ("Beak").transform.position = new Vector2 (39f, 6f);
				birdObj.transform.FindChild ("LegFront").transform.position = new Vector2 (-17f, -23f);
				birdObj.transform.FindChild ("LegBack").transform.position = new Vector2 (-8f, -23f);
				birdObj.transform.FindChild ("Tail").transform.position = new Vector2 (-36f, 4f);
				birdObj.name = birdToAdd.Title;
				break;
			}
		}

	}
	/*
	//check if bird is in inventory
	bool isInInventory (Item item) {
		for (int i = 0; i < birds.Count; i++) {
			if (birds [i].ID == item.ID) {
				return true;
			}
		}
		return false;
	}


	int ItemCheck(Item item) {
		for (int i = 0; i < birds.Count; i++) {
			if (birds [i].ID == item.ID) {
				return i;
			}
		}
		return -1;
	}

	public void RemoveItem(int id) {
		Item itemToRemove = database.FetchBirdByID (id);
		int pos = ItemCheck (itemToRemove);
		if (pos != -1) {
			if (birds [pos].Stackable) {
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
	}*/
}
