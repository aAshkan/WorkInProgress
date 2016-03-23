using UnityEngine;
using System.Collections;

public class testingMouseDown : MonoBehaviour {

	//performs an action, in this case a jump on the object that is being clicked.
	//could be used as a button to instead alter the player object.
	
	// Use this for initialization
	void Start () {
	
	}
	void  OnMouseDown() {
		 GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
