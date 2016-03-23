using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour {
	//Inventory inventory;
	//GameObject bird;

	[SerializeField]
	private BirdDatabase database;

	[SerializeField]
	private EquippedBirdChecker equippedBird;

	[SerializeField]
	private GameObject birdInfo;

	[SerializeField]
	private GameObject birdImage;

	[SerializeField]
	private string data = "No Bird Selected";
	//playerStats stats;

	// Use this for initialization
	void Start () {
		birdImage = GameObject.Find ("Inventory Panel/Character Panel/Bird Image");
		birdInfo = GameObject.Find ("Inventory Panel/Character Panel/Bird Info/Text");
		database = GameObject.Find ("Equipped Bird").GetComponent<BirdDatabase> ();
		equippedBird = GameObject.Find ("Equipped Bird").GetComponent<EquippedBirdChecker> ();
		Bird bird = equippedBird.returnBird ();

		if (bird != null ) {
			birdImage.transform.FindChild ("Eye").GetComponent<Image> ().sprite = database.dictSprites[bird.EyeSlug];
			birdImage.transform.FindChild ("Blush").GetComponent<Image> ().sprite = database.dictSprites[bird.BlushSlug];
			birdImage.transform.FindChild ("Body").GetComponent<Image> ().sprite = database.dictSprites[bird.BodySlug];
			birdImage.transform.FindChild ("WingFront").GetComponent<Image> ().sprite = database.dictSprites[bird.WingFrontSlug];
			birdImage.transform.FindChild ("WingBack").GetComponent<Image> ().sprite = database.dictSprites[bird.WingBackSlug];
			birdImage.transform.FindChild ("Beak").GetComponent<Image> ().sprite = database.dictSprites[bird.BeakSlug];
			birdImage.transform.FindChild ("LegBack").GetComponent<Image> ().sprite = database.dictSprites[bird.LegBackSlug];
			birdImage.transform.FindChild ("LegFront").GetComponent<Image> ().sprite = database.dictSprites[bird.LegFrontSlug];
			birdImage.transform.FindChild ("Tail").GetComponent<Image> ().sprite = database.dictSprites[bird.TailSlug];

			Debug.Log ("Hi");

			data = "Speed: " + bird.Speed + "\n"
				+ "Bounce: " + bird.Bounce + "\n"
				+ "Health: " + bird.Health + "\n"
				+ "Ammo: " + bird.Ammo + " \n"
				+ "AmmoType: " + bird.AmmoType + "\n"
				+ "Vision: " + bird.Vision + "\n"
				+ "Size: " + bird.Size + "";
		} else {
			data = "You have yet to equip a bird";
		}
		/*+ "Flap: " + bspeed +  "\n"
			+ "Ammo Type: " + ammoType + "\n"
			+ "Vision: " + vision +  "\n"
			+ "Size: " + size;*/

		birdInfo.transform.GetComponent<Text> ().text = data;

		//ConstructBirdImage ();
		//ConstructBirdInfo ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void ConstructBirdInfo() {
		
		//ConstructBirdData (1,2,1,1,1,1,1);
	}
	public void ConstructBirdData(float s, float hp, float a) {
		
		string sp = "";
		string h = "";
		string am = "";

		if (s > 0) {
			sp = "+" + s;
		}

		if (hp > 0) {
			h = "+" + hp;
		}

		if (a > 0) {
			am = "+" + a;
		}


		
	}
}
