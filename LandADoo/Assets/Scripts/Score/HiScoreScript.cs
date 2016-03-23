using UnityEngine;
using System.Collections;

public class HiScoreScript : MonoBehaviour {
	//this script holds all the high scores posted for EACH level.
	public static HiScoreScript hScoreScript;

	public int[] highScoreArr = new int[24]; //24 levels; 3 worlds; 8 levels per world.

	void Awake () {
		if (hScoreScript == null) {
			DontDestroyOnLoad (gameObject);
			hScoreScript = this;
		} else if (hScoreScript != this) {
			Destroy (gameObject);
		}

		for (int i = 0; i < highScoreArr.Length; i++) {
			highScoreArr [i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
