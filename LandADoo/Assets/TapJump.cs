using UnityEngine;
using System.Collections;

//moves an object by applying an upward force when the mouse is clicked, (or the screen is tapped) I hope.

public class TapJump : MonoBehaviour {
     public float jumpPower = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//touch version
		//for (var i = 0; i < Input.touchCount; i++){
		//	if (Input.GetTouch(i).phase == TouchPhase.Began) {
		//		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
		//	}
		//}
		//mouse version
	    if (Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
		}
	}
}
