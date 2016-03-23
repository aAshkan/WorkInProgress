using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BreedButton : MonoBehaviour {
	private BirdInventory inv;
	private GameObject breedPanel;
	private GameObject slotOne;
	private GameObject slotTwo;
	private BirdData bird1;
	private BirdData bird2;
	private Bird mother;
	private Bird father;
	private BirdDatabase database;

	// Use this for initialization
	void Start () {
		breedPanel = GameObject.Find ("Inventory Panel/Breed Panel");
		inv = GameObject.Find ("BirdInventory").GetComponent<BirdInventory> ();
		database = GameObject.Find ("BirdInventory").GetComponent<BirdDatabase> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void Breed () {
		slotOne = breedPanel.transform.GetChild (0).gameObject;
		slotTwo = breedPanel.transform.GetChild (1).gameObject;
		if (slotOne.transform.childCount > 0 && slotTwo.transform.childCount > 0) {
			Debug.Log ("breeded");
			createNewBird (slotOne.transform.GetChild(0).gameObject, slotTwo.transform.GetChild(0).gameObject);
		} else {
			Debug.Log ("No breeding");
			return;
		}
	}

	void createNewBird(GameObject one, GameObject two) {
		//Debug.Log (one.name);
		if (slotOne != null) {
			mother = one.GetComponent<BirdData> ().bird;
			father = two.GetComponent<BirdData> ().bird;
			int speed = Random.Range (mother.Speed, father.Speed);
			int bounce = Random.Range (mother.Bounce, father.Bounce);
			int health = Random.Range (mother.Health, father.Health);
			int ammo = Random.Range (mother.Ammo, father.Ammo);
			int ammoType = Random.Range (mother.AmmoType, father.AmmoType);
			int vision = Random.Range (mother.Vision, father.Vision);
			int size = Random.Range (mother.Size, father.Size);
			string name = "new bird";
			string eyeSlug = "eyes_0";
			string blushSlug = "blush_0";
			string bodySlug = "normal-body_0";
			string wingFrontSlug = "frontwing_0";
			string wingBackSlug = "backwing_0";
			string beakSlug = "beaks_0";
			string legFrontSlug = "feet_1";
			string legBackSlug = "feet_0";
			string tailSlug = "tail_0";

			//------change sprite based on stats
			//speed = wing
			if (speed == 2) {
				wingFrontSlug = "frontwing_1";
				wingBackSlug = "backwing_1";
			} else if (speed == 3) {
				wingFrontSlug = "frontwing_0";
				wingBackSlug = "backwing_0";
			} else if (speed == 4) {
				wingFrontSlug = "frontwing_2";
				wingBackSlug = "backwing_2";
			} else if (speed == 5) {
				wingFrontSlug = "frontwing_3";
				wingBackSlug = "backwing_3";
			}
				
			//bounce = tail
			if (bounce == 2) {
				tailSlug = "tail_1";
			} else if (bounce == 3) {
				tailSlug = "tail_0";
			} else if (bounce == 4) {
				tailSlug = "tail_2";
			} else if (bounce == 5) {
				tailSlug = "tail_3";
			}

			//health = beak
			if (health == 1) {
				beakSlug = "beaks_2";
			} else if (health == 2) {
				beakSlug = "beaks_3";
			} else if (health == 3) {
				beakSlug = "beaks_4";
			} else if (health == 4) {
				beakSlug = "beaks_1";
			} else if (health == 5) {
				beakSlug = "beaks_5";
			}

			//vision = eye
			if (vision == 1) {
				eyeSlug = "eyes_0";
			} else if (vision == 2) {
				eyeSlug = "eyes_1";
			} else if (vision == 3) {
				eyeSlug = "eyes_2";
			}

			//size = body

			//ammo = leg


			//Add new Bird to database and reload scene
			if (mother != null && father != null) {
				database.addToDatabase (name, speed, bounce, health, ammo, ammoType, vision, size, eyeSlug, blushSlug, bodySlug, wingFrontSlug, wingBackSlug, beakSlug, legFrontSlug, legBackSlug, tailSlug);
				Debug.Log("Database size after adding" + database.returnDatabaseSize ());
				//inv.StartCoroutine ();

				SceneManager.LoadScene(8);

			} else {
				Debug.Log ("is null");
			}
			//Debug.Log (bird1.giveBirdData);
		} else {
			return;
		}
		if (slotTwo != null) {
			father = two.GetComponent<BirdData> ().bird;
		} else {
			return;
		}

		Debug.Log ("creating sprite");

	}

}
