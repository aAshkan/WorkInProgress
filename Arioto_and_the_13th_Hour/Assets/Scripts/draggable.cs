using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	private Vector2 startingPoint;
	private Vector2 offsets;
	private gameManager GM;
	private bool type = false;
	public Transform parentToReturnTo = null;

	void Awake(){
		GM = this.gameObject.GetComponentInParent<gameManager> ();
		if (this.gameObject.tag == "Player")
			type = true;
	}

	public void OnBeginDrag(PointerEventData eventData){
		if (GM.PlayersTurn == type) {
			parentToReturnTo = this.transform.parent;
			this.transform.SetParent( this.transform.parent.parent );
			startingPoint = new Vector2 (eventData.position.x, eventData.position.y);
			offsets = new Vector2 (startingPoint.x - this.transform.position.x,
		                      		startingPoint.y - this.transform.position.y);
		}
	}

	public void OnDrag(PointerEventData eventData){
		if (GM.PlayersTurn == type) {
			this.transform.position = new Vector2 (40 * Mathf.Round ((eventData.position.x - offsets.x) / 40), 
			                                       40 * Mathf.Round ((eventData.position.y - offsets.y) / 40));
				//eventData.position - offsets;
		}
	}

	public void OnEndDrag(PointerEventData eventData){
		if (GM.PlayersTurn == type) {
			this.transform.position = new Vector2 (40 * Mathf.Round ((eventData.position.x - offsets.x) / 40), 
			                                       40 * Mathf.Round ((eventData.position.y - offsets.y) / 40));

			if (isValidMove ())
				callManager ();
			else
				this.transform.position = startingPoint - offsets; //set back to starting point
			this.transform.SetParent( parentToReturnTo );
		}

	}

	private bool isValidMove(){
		position pos;

		if((this.transform.localPosition.x > (40*6) || this.transform.localPosition.x < 0) || 
		   (this.transform.localPosition.y > (40*9) || this.transform.localPosition.y < 0)){
			return false;
		}

		if(GM.collisionCheck(this.gameObject)){
			return false;
		}

		pos = new position (Mathf.RoundToInt(this.gameObject.transform.localPosition.x / 40),
		                    Mathf.RoundToInt(this.gameObject.transform.localPosition.y / 40));

		GM.g.FindPath (this.GetComponent<characters> ().pos, pos);

		//GM.g.printPath ();
		if(GM.g.path == null)
			return false;

		return true;
	}

	private void callManager(){
		GM.setLastMoved (this.gameObject);
		GM.update();
	}
}
