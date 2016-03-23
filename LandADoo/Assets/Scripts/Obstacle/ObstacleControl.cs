using UnityEngine;
using System.Collections;

public class ObstacleControl : MonoBehaviour {
	//for the enemy speed
	public float speed;
	public float maxSpeed;
	float randomSpeed;

	// Use this for initialization
	void Start () {
		randomSpeed = Random.Range(speed, maxSpeed); //speed of car will be randomized
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		//Get the enemy current position
		Vector2 position = transform.position;

		//Compute the enemy new position
		position = new Vector2 (position.x - (randomSpeed * Time.deltaTime), position.y); 

		//Update the enemy position
		transform.position = position;

		//This is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Destroy enemy if goes out of screen
		if ((transform.position.x+5) < min.x) {
			Destroy (gameObject);
		}
	}

	public float getRandSpeed(){
		return randomSpeed;
	}
}
