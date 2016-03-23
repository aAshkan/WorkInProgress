using UnityEngine;
using System.Collections;
//simple sidescrolling camera at speed "speed"
public class CameraManager : MonoBehaviour {
	
	[SerializeField]
	public static float speed = 3f;

	public void updateSpeed (int s) {
		speed = s;
	}

	// Update is called once per frame
	void Update () {
	transform.position += Vector3.right*speed * Time.deltaTime;
	}
}
