using UnityEngine;
using System.Collections;

public class CityGarbageCollector : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {

		//This is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Destroy enemy if goes out of screen
		if ((transform.position.x+5) < min.x-35) {
			Destroy (gameObject);
		}
	}
}
