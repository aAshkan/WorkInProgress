using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.IO;

//Script is attached to Bird's prefab
public class BirdData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler {
	public Bird bird;
	public int slot; //slot of item thats in
	private BirdInventory inv;
	private BirdInfo tooltip;
	private Vector2 offset;
	public Sprite normal;
	public Sprite selectedSprite;
	private bool changeSprite = false;

	void Start() {
		inv = GameObject.Find ("BirdInventory").GetComponent<BirdInventory> (); //get BirdInventory script
		tooltip = inv.GetComponent<BirdInfo> ();
		//normal = Resources.Load<Sprite>("Assets/Resources/Sprites/UI/emptyItemBox");
		//selectedSprite = Resources.Load<Sprite>("Assets/Resources/Sprites/UI/popupTutorialTextBox");
	}

	void Update() {
		if (changeSprite == true) {
			this.transform.parent.GetComponent<Image> ().sprite = selectedSprite;
		}  else if (changeSprite == false) {
			this.transform.parent.GetComponent<Image> ().sprite = normal;
		}
	}

	//when pressed down, grab bird and position it to mouse and activate bird info
	public void OnPointerDown(PointerEventData eventData){
		if (bird != null) {
			offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
			tooltip.Activate (bird);
		}

		changeSprite = true;

	}

	//when begin dragging: change position of item/bird based on mice pos 
	public void OnBeginDrag(PointerEventData eventData) {

		if (bird != null) {
			this.transform.SetParent (this.transform.parent.parent.parent.parent);
			this.transform.position = eventData.position;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
			
	}

	//update position while dragging
	public void OnDrag(PointerEventData eventData) {
		if (bird != null) {
			this.transform.position = eventData.position;

		}
	}

	//when stopped dragging, set bird/item's parent and position
	public void OnEndDrag(PointerEventData eventData) {

		this.transform.SetParent (inv.slots [slot].transform);
		this.transform.position = inv.slots [slot].transform.position;

		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		changeSprite = false;
	}


	public void OnPointerExit(PointerEventData eventData){
		changeSprite = false;
		//tooltip.Deactivate ();
	}

	/*public float giveBirdData() {
		return bird.Speed;
	}*/
}
