using UnityEngine;
using System.Collections;

//Check to see which items are equipped (NOT DONE)
public class EquipChecker : MonoBehaviour {
	public static EquipChecker Instance;
	public static Item item1 = new Item();
	public static Item item2 = new Item();
	public static Item item3 = new Item();


	void Start () {
		Debug.Log (item1.Title);
		Debug.Log (item1.Slug);
	}
	//is called whenever a bird is placed on equip slot
	public void equippedItemOne (Item one) {
		item1 = one;

		Debug.Log (item1.Title);
		Debug.Log (item1.ID);
	}

	public void equippedItemTwo (Item two) {
		item2 = two;

		Debug.Log (item2.Title);
		Debug.Log (item2.ID);
	}

	public void equippedItemThree (Item three) {
		item3 = three;

		Debug.Log (item3.Title);
		Debug.Log (item3.ID);
	}

	public Item returnItem1() {
		return item1;
	}

	public Item returnItem2() {
		return item2;
	}

	public Item returnItem3() {
		return item3;
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
	}

	/*private GameObject equipPanel;
	private GameObject slotOne;
	private GameObject slotTwo;
	private GameObject slotThree;
	// Use this for initialization
	void Start () {
		equipPanel = GameObject.Find ("Inventory Panel/Equip Panel");
		slotOne = equipPanel.transform.GetChild (0).gameObject;
		slotTwo = equipPanel.transform.GetChild (1).gameObject;
		slotThree = equipPanel.transform.GetChild (2).gameObject;
		IncreaseStats ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void IncreaseStats() {
		if (slotOne.transform.childCount > 0) {
			Debug.Log ("POOOP");
			if (slotOne.transform.name == "Poop") {
				Debug.Log ("POOOP2");
			}
		}

		if (slotTwo.transform.childCount > 0) {
			
		}

		if (slotThree.transform.childCount > 0) {

		}
	}*/
}
