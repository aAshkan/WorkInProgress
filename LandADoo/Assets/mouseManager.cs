using UnityEngine;
using System.Collections;

public class mouseManager : MonoBehaviour {
	
	public LineRenderer dragLine;
	public float speed;
	bool drawLine = false;
	bool shooting = false;
	private float deltaX;
	Vector2 start = Vector2.zero;
	Vector2 end = Vector2.zero;
	void Start () {
		deltaX = 0f;
		speed = 3f;
		dragLine.enabled = false;
	}
	void Update () {
		Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos2D = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);

		if (Input.GetMouseButtonDown (0)) {

			Vector2 dir = Vector2.zero;
			RaycastHit2D hit = Physics2D.Raycast (mousePos2D, dir);
			if (hit.collider != null) {
				if (hit.collider.name == "Square" || hit.collider.name == "Birdy") {
					shooting = true;
					//we clicked on something that has a collider
					drawLine = true;
					Debug.Log (hit.collider.name);	
					start = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);
					dragLine.enabled = true;
					deltaX = start.x;
				}
			}
		}
		if (Input.GetMouseButtonUp (0) && shooting == true) {
			end = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);
			dragLine.enabled = false;
			GameObject poopObj = GameObject.Find ("Pooper");
			Pooper pooper = poopObj.GetComponent<Pooper> ();
			pooper.firePoopFunc (new Vector2(deltaX+(speed*Time.deltaTime), start.y), end);
			//Debug.Log ("start: " + start);
			//Debug.Log ("end: " + end);
			shooting = false;
			drawLine = false;
		}
		deltaX += speed * Time.deltaTime;
	}

	void FixedUpdate () {
	}

	void LateUpdate() {
		Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos2D = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);
		if (drawLine) {
			dragLine.SetPosition (0, new Vector3 (deltaX, start.y, -1));
			dragLine.SetPosition (1, new Vector3 (mousePos2D.x, mousePos2D.y, -1));
			//Debug.Log ("Anchor: "+start.x + (speed * Time.deltaTime)+", "+start.y);
		}
	}
}
