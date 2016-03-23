using UnityEngine;
using System.Collections;

public class poopSplatterMove : MonoBehaviour {

	float x_vel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 position = transform.position ;
		//Debug.Log ("X: " + x_vel);
		//Debug.Log("x_pos: "+position.x);
		//Debug.Log ("TIME: " + Time.deltaTime);
		//Debug.Log ("Prod: " + x_vel * Time.deltaTime);
		position = new Vector2 (position.x - (x_vel * Time.deltaTime), position.y);

		transform.position = position;
	}

	public void setXVel(float x){
		x_vel = x;
	}
}
