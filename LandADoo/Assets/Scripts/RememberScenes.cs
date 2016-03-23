using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class RememberScenes : MonoBehaviour {

	//public int slotNumber;
	//public int equippedItem;
	//public List<GameObject> slots = new List<GameObject>();

	void Awake() {
		DontDestroyOnLoad (this);

	}
}
