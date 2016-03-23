using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//Store all the birds and their stats
public class BirdDatabase : MonoBehaviour {
	[SerializeField]
	private static List<Bird> database = new List<Bird>();

	public Dictionary<string, Sprite> dictSprites = new Dictionary<string, Sprite>();

	void Start () {

		//Load sprite sheets into arrays
		Sprite[] frontwing = Resources.LoadAll<Sprite>("Sprites/Birds/FrontWing");
		Sprite[] backwing = Resources.LoadAll<Sprite>("Sprites/Birds/BackWing");
		Sprite[] beak = Resources.LoadAll<Sprite>("Sprites/Birds/Beak");
		Sprite[] tail = Resources.LoadAll<Sprite>("Sprites/Birds/Tail");
		Sprite[] eye = Resources.LoadAll<Sprite>("Sprites/Birds/Eyes");
		Sprite[] body = Resources.LoadAll<Sprite>("Sprites/Birds/Body");
		Sprite[] leg = Resources.LoadAll<Sprite>("Sprites/Birds/Feet");
		Sprite[] head = Resources.LoadAll<Sprite>("Sprites/Birds/Head");
		Sprite[] blush = Resources.LoadAll<Sprite>("Sprites/Birds/Blush");

		//Store sprites and their name into a dictionary
		foreach (Sprite sprite in frontwing)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in backwing)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in beak)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in tail)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in eye)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in body)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in leg)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in head)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}
		foreach (Sprite sprite in blush)
		{
			dictSprites.Add (sprite.name, sprite);
			Debug.Log (sprite.name);
		}

		//First add two birds into database. This is just for testing, so we can see if breeding works
		if (database.Count < 2) {
			ConstructBirdDatabase ();
		}


		Debug.Log ("hello");
		Debug.Log (database.Count);

	}

	//return database of bird based on ID passed
	public Bird FetchBirdByID(int id) {

		for (int i = 0; i < database.Count; i++) {
			if (database [i].ID == id) {
				return database [i];
			}
		}
		return null;
	}

	//add new bird to database
	public void addToDatabase(string name, int s, int b, int h, int a, int aT, int v, int si, string eye, string blush, string body, string wingfront, string wingback, string beak, string legfront, string legback, string tail) {
		int size = database.Count;

		database.Add(new Bird(size, name, s, b, h, a, aT, v, si, eye, blush, body, wingfront, wingback, beak, legfront, legback, tail));
		Debug.Log ("added new bird");
		Debug.Log (size);

	}

	//return the size of database
	public int returnDatabaseSize(){
	 	return database.Count;
	}

	//Just a testing function 
	void ConstructBirdDatabase(){
		database.Add(new Bird(0, "Jarret", 2, 2, 1, 10, 1, 1, 1, "eyes_0", "blush_0", "normal-body_0", "frontwing_1", "backwing_1", "beaks_2", "feet_1", "feet_0", "tail_1"));
		database.Add(new Bird(1, "Vi", 5, 5, 5, 15, 4, 4, 4, "eyes_2", "blush_1", "normal-body_0", "frontwing_3", "backwing_3", "beaks_5", "feet_1", "feet_0", "tail_3"));
	}
}
	
//Stats declared here
public class Bird {
	public BirdDatabase database;
	public int ID { get; set; }
	public string Title { get; set; }
	public int Speed { get; set; }
	public int Bounce { get; set; }
	public int Health { get; set; }
	public int Ammo { get; set; }
	public int AmmoType { get; set; }
	public int Vision { get; set; }
	public int Size { get; set; }
	public string EyeSlug { get; set; } //slug = name of sprite
	public string BlushSlug { get; set; }
	public string BodySlug { get; set; }
	public string WingFrontSlug { get; set; }
	public string WingBackSlug { get; set; }
	public string BeakSlug { get; set; }
	public string LegFrontSlug { get; set; }
	public string LegBackSlug { get; set; }
	public string TailSlug { get; set; }
	public Sprite Eye { get; set; } 
	public Sprite Blush { get; set; }
	public Sprite Body { get; set; } 
	public Sprite WingFront { get; set; } 
	public Sprite WingBack { get; set; }
	public Sprite Beak { get; set; } 
	public Sprite FrontLegs { get; set; } 
	public Sprite BackLegs { get; set; } 
	public Sprite Tail { get; set; } 


	//constructor
	public Bird (int id, string title, int speed, int bounce, 
				int health, int ammo, int ammoType, int vision, 
		int size, string eyeSlug, string blushSlug, string bodySlug, string wingFrontSlug, string wingBackSlug, string beakSlug,
		string frontLegsSlug, string backLegsSlug, string tailSlug) {
		this.ID = id;
		this.Title = title;
		this.Speed = speed;
		this.Bounce = bounce;
		this.Health = health;
		this.Ammo = ammo;
		this.AmmoType = ammoType;
		this.Vision = vision;
		this.Size = size;
		this.EyeSlug = eyeSlug;
		this.BlushSlug = blushSlug;
		this.BodySlug = bodySlug;
		this.WingFrontSlug = wingFrontSlug;
		this.WingBackSlug = wingBackSlug;
		this.BeakSlug = beakSlug;
		this.LegFrontSlug = frontLegsSlug;
		this.LegBackSlug = backLegsSlug;
		this.TailSlug = tailSlug;

	}

	//added birds that does not have any stats set
	public Bird () {
		this.ID = -1;
	}
}
