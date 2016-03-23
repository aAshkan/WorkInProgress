using UnityEngine;
using System.Collections;

public class MovingBall : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;

		//Compute the enemy new position
		position = new Vector2 (position.x + (speed * Time.deltaTime), position.y); 

		//Update the enemy position
		transform.position = position;
	
	}
}
