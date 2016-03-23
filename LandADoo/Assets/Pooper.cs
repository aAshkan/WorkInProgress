using UnityEngine;
using System.Collections;

public class Pooper : MonoBehaviour {

	public GameObject poops;
	public GameObject bird;
	public GameObject bg; //background
	public bool firePoop;
	// Use this for initialization
	public float fireDelay = 3f;
	public float initVelocity = 30f;

	void Update() {
	}

	void FixedUpdate () {
	}
	public void firePoopFunc (Vector2 start, Vector2 end){
		bool goodDistance = false;
		Vector2 difference = new Vector2 (start.x - end.x, start.y - end.y);
		float distance = Mathf.Sqrt (Mathf.Pow (difference.x, 2f) + Mathf.Pow (difference.y, 2f));
		//Debug.Log ("Distance: " + distance);
		if (distance >= 0.5)
			goodDistance = true;
		if (start.y >= end.y && goodDistance) {
			Vector2 v2 = end - start;
			v2 = v2.normalized;

			GameObject poopGO = (GameObject)Instantiate (poops, bird.transform.position, Quaternion.identity);

			poopGO.GetComponent<Rigidbody2D> ().velocity = (v2 * initVelocity) + new Vector2 (3f, 0); //okay this new vec2 is just so the poop has an initial velocity matching the bird. yes i know its bad code :3
			//Physics2D.IgnoreCollision (poopGO.GetComponent<Collider2D> (), bg.GetComponent<Collider2D> ());
			Physics2D.IgnoreCollision (poopGO.GetComponent<Collider2D> (), bird.GetComponent<Collider2D> ());

			//Vi's poop code

			PoopScore.poop -= 1;

		} else if (goodDistance) {
			Debug.Log ("shooting up against gravity?");
		} else {
			Debug.Log ("not long enough!");
		}
	}
}
