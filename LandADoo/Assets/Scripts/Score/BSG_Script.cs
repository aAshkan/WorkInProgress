using UnityEngine;
using System.Collections;

public class BSG_Script : MonoBehaviour {

	//Bronze Silver Gold persistent data script
	//1 for bronze, 2 silver, 3 gold. easy enough.
	public static BSG_Script BSG;
	public int[] BSG_Arr = new int[24];

	void Awake () {
		if (BSG == null) {
			DontDestroyOnLoad (gameObject);
			BSG = this;
		} else if (BSG != this) {
			Destroy (gameObject);
		}

		for (int i = 0; i < BSG_Arr.Length; i++) {
			BSG_Arr [i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
