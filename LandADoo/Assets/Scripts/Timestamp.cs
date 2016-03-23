using UnityEngine;
using System.Collections;

public class Timestamp : MonoBehaviour {
	
	public static float timeSinceStart;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void GameStart() {
		timeSinceStart = Time.realtimeSinceStartup;
	}
}
