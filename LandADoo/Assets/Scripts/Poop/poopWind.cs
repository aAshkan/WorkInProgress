using UnityEngine;
using System.Collections;

public class poopWind : MonoBehaviour {
	
	void FixedUpdate () {
		if(this.GetComponent<Rigidbody2D>())
			this.GetComponent<Rigidbody2D> ().velocity += wind.getWindVel();
	}
}
