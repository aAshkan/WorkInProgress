using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	public GameObject launchPrefab;
	public float fireDelay = 3f;
	float nextFire = 1f;

	public float fireVelocity = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		nextFire -= Time.deltaTime;

		if (nextFire <= 0) {
			nextFire = fireDelay;

			GameObject launchThis = (GameObject)Instantiate (launchPrefab, transform.position, transform.rotation);
			launchThis.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
		}
	}
}
