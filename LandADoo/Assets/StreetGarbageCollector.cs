using UnityEngine;
using System.Collections;

public class StreetGarbageCollector : MonoBehaviour {

	[SerializeField]
	public static float speed;

	// Update is called once per frame
	void FixedUpdate () {
		
		//This is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Destroy enemy if goes out of screen
		if ((transform.position.x+10) < min.x) {
			Destroy (gameObject);
		}

		Vector2 position = transform.position;
		position = new Vector2 (position.x + (speed * Time.deltaTime), position.y); 
		transform.position = position;
	}
}
