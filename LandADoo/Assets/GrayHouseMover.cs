using UnityEngine;
using System.Collections;

public class GrayHouseMover : MonoBehaviour {

	public static float speed = CameraManager.speed/6;

	// Update is called once per frame
	void FixedUpdate () {

		//This is the bottom-left of screen
		Vector2 position = transform.position;
		position = new Vector2 (position.x + (speed * Time.deltaTime), position.y); 
		transform.position = position;
	}
}