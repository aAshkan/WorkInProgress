using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//convert Json to C# Object or take a C# Object and create a Json Object

public class ItemDatabase : MonoBehaviour {
	[SerializeField]
	private static List<Item> itemDatabase = new List<Item>();
	//public Dictionary<string, Sprite> dictSprites = new Dictionary<string, Sprite>();


	void Start () {
		/*Sprites = Resources.LoadAll<Sprite>("Sprites/Inventory/Items/bird_pieces");

		foreach (Sprite sprite in sprites)
		{
			dictSprites.Add (sprite.name, sprite);
		}*/
		Debug.Log ("Construct");

		ConstructItemDatabase ();

		//itemDatabase.Add(new Item(0, "Poop", 1, 0, 0, 5, 0, 0, "A shiny brown poop that give you 5 extra Doo-Doos to use during mission.", true, "poop_icon"));
		//Debug.Log (FetchItemByID(0).Description);
	}

	//return database of item based on ID passed
	public Item FetchItemByID(int id) {

		for (int i = 0; i < itemDatabase.Count; i++) {
			if (itemDatabase [i].ID == id) {
				return itemDatabase [i];
			}
		}
		return null;
	}

	public void removeItem(Item item) {
		if (item != null) {
			Debug.Log (item.Title);
			itemDatabase.Remove (item); 
			Debug.Log ("Item removed");
			Debug.Log (item.Title);
		} else {
			Debug.Log ("item is null");
		}

	}

	/*public void addToDatabase(string name, int s, int b, int h, int a, int aT, int v, int si, string eye, string blush, string body, string wingfront, string wingback, string beak, string legs, string tail) {
		int size = database.Count;

		database.Add(new Item(size, name, s, b, h, a, aT, v, si, eye, blush, body, wingfront, wingback, beak, legs, tail));
		Debug.Log ("added new bird");
		Debug.Log (size);

	}*/

	//return the size of database
	public int returnDatabaseSize(){
		return itemDatabase.Count;
	}



	//Loop through itemData and add all items to database
	void ConstructItemDatabase(){
		Debug.Log ("inside construct");
		itemDatabase.Add(new Item(0, "Poop", 1, 0, 0, 5, 0, 0, "A shiny brown poop that give you 5 extra Doo-Doos to use during mission.", true, "poop_icon"));
		Debug.Log ("added first item");
		itemDatabase.Add(new Item(1, "Wing", 1, 1, 0, 0, 0, 0, "A beautiful blue wing give your bird an extra speed.", true, "speed_icon"));
		Debug.Log ("added second item");
		itemDatabase.Add(new Item(2, "Heart", 1, 0, 0, 0, 1, 0, "A shiny red heart that gives your bird an extra health.", true, "health_icon"));
		Debug.Log ("added third item");
		/*for (int i = 0; i < itemData.Count; i++) {
			database.Add(new Item( 
				(int)itemData[i]["id"], 
				itemData[i]["title"].ToString(), 
				(int)itemData[i]["value"],
				(int)itemData[i]["stats"]["speed"],
				itemData[i]["description"].ToString(),
				(bool)itemData[i]["stackable"],
				itemData[i]["slug"].ToString(),
				itemData[i]["location"].ToString()
			));
		}*/
	}
}



public class Item {
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value {get; set; }
	public int Speed { get; set; }
	public int Bounce { get; set; }
	public int Ammo { get; set; }
	public int Health { get; set; }
	public int Vision { get; set; }
	public string Description { get; set; }
	public bool Stackable  { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; } 
	//public ItemDatabase dictSprites;
	//private Sprite[] Sprites;



	//constructor
	public Item (int id, string title, int value, int speed, int bounce, int ammo, int health, int vision, string description, bool stackable, string slug) {
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Speed = speed;
		this.Bounce = bounce;
		this.Ammo = ammo;
		this.Health = health;
		this.Vision = vision;
		this.Description = description;
		this.Stackable = stackable;
		this.Slug = slug;
		//this.Sprite = dictSprites [slug];
		this.Sprite = Resources.Load<Sprite> ("Sprites/Inventory/Items/" + slug);
	}



	//added item that does not have any value set
	public Item () {
		this.ID = -1;
	}
}
