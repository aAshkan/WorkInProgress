using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Tooltip = bird's data info pop up when selecting
public class Tooltip : MonoBehaviour {

	private Item item;

	private string data;

	private GameObject tooltip;

	private GameObject itemImage;

	private Inventory inv;

	// Use this for initialization
	void Start () {
		//inv = GameObject.Find ("Inventory"). GetComponent<Inventory> ();
		itemImage = GameObject.Find ("Item Info/ItemImage");
		tooltip = GameObject.Find ("Item Info/Tooltip");
		tooltip.SetActive (false);
		itemImage.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	}

	//call this function to activate/show item info panal 
	public void Activate (Item item) {
		this.item = item;
		ConstructDataString ();
		tooltip.SetActive (true);
		itemImage.SetActive (true);
	}

	//deactive/hide item info panel
	public void Deactivate() {
		tooltip.SetActive (false);
		itemImage.SetActive (false);

	}

	//modify/display item info based on which item mouse is pressed on
	public void ConstructDataString() {
		data = item.Title + "\n\n" + item.Description;
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		itemImage.GetComponent<Image> ().sprite = item.Sprite;


	}

	

}
