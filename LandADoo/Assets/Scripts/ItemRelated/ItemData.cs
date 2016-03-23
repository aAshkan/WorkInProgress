using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot; //slot of item thats in
	[SerializeField]
	private Inventory inv;
	[SerializeField]
	private Equipment equip;
	[SerializeField]
	private Tooltip tooltip;
	[SerializeField]
	private Vector2 offset;
	//CharacterPanel characterPanel;

	void Start() {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
//		equip = GameObject.Find ("Equipment").GetComponent<Equipment> ();
		tooltip = inv.GetComponent<Tooltip> ();
		//characterPanel = GameObject.Find("Character Panel").GetComponent<CharacterPanel>(); 
	}

	public void OnPointerDown(PointerEventData eventData){
		if (item != null){
			offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
			tooltip.Activate (item);
		}

	}

	public void OnBeginDrag(PointerEventData eventData) {

		if (item != null) {
			this.transform.SetParent (this.transform.parent.parent.parent.parent);
			this.transform.position = eventData.position;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}

		//throw new NotImplementedException ();
	}
	public void OnDrag(PointerEventData eventData) {
		if (item != null) {
			this.transform.position = eventData.position;
		
		}
		//throw new NotImplementedException ();
	}
	public void OnEndDrag(PointerEventData eventData) {

		//if (eventData.position == inv.transform.position) {
		this.transform.SetParent (inv.slots [slot].transform);
		this.transform.position = inv.slots [slot].transform.position;

		/*} else {
			this.transform.SetParent (equip.equipSlots [slot].transform);
			this.transform.position = equip.equipSlots [slot].transform.position;
		}*/
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		//throw new NotImplementedException ();
	}


	public void OnPointerExit(PointerEventData eventData){
		//tooltip.Deactivate ();
	}
}
