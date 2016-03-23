
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shootScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler {
	
	public static shootScript instance;
	public LineRenderer dragLine;
	public Material redLineMat, blueLineMat;

	public float speed;
	bool drawLine = false;
	bool shooting = false;
	bool outside = false;
	bool mouseDown = false;
	private float deltaX;
	private Button shootButton;
	Vector2 start = Vector2.zero;
	Vector2 end = Vector2.zero;
	Vector3 mouseWorldPos3D = Vector3.zero;
	Vector2 mousePos2D = Vector2.zero;

	void Awake(){
		if (instance == null)
		{
			instance = this;
		}
	}
	void Start () {
		deltaX = 0f;
		speed = 3f;
		dragLine.enabled = false;
	}
	void Update () {
		if (mouseDown) { //button is pressed
			shooting = true;
			drawLine = true;
			dragLine.enabled = true;
		}
		if (shooting) {
			//Debug.Log("AHH");
			mouseWorldPos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			end = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);
		}
		deltaX += speed * Time.deltaTime;


	}
	public void OnPointerDown(PointerEventData eventData){
		mouseWorldPos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		start = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);
		deltaX = start.x;
		mouseDown = true;
	}
	public void OnPointerUp(PointerEventData eventData){
		mouseDown = false;
		shooting = false;
		drawLine = false;
		dragLine.enabled = false;
		if (outside) {
			GameObject poopObj = GameObject.Find ("Pooper");
			Pooper pooper = poopObj.GetComponent<Pooper> ();
			pooper.firePoopFunc (new Vector2 (deltaX + (speed * Time.deltaTime), start.y), end);
		} else {
		}
		outside = false;

	}

	public void OnPointerExit(PointerEventData eventData){
		outside = true;
	}
	//void FixedUpdate () {
	//}

	void LateUpdate() {
		Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos2D = new Vector2 (mouseWorldPos3D.x, mouseWorldPos3D.y);
		if (drawLine) {
			dragLine.SetPosition (0, new Vector3 (deltaX, start.y, 0));
			dragLine.SetPosition (1, new Vector3 (mousePos2D.x, mousePos2D.y, 0));
			//Debug.Log ("Anchor: "+start.x + (speed * Time.deltaTime)+", "+start.y);

			Vector2 difference = new Vector2 (deltaX - mousePos2D.x, start.y - mousePos2D.y);
			float distance = Mathf.Sqrt (Mathf.Pow (difference.x, 2f) + Mathf.Pow (difference.y, 2f));
			if (distance >= 1.0) //edit this distance to change the line coloring
				dragLine.material = blueLineMat;
			else
				dragLine.material = redLineMat;
		}
	}
}
