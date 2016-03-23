using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	private GameObject directionBird;
	private EquipChecker itemChecker;
	private EquippedBirdChecker birdChecker;
	private Item item;


	// Use this for initialization
	void Start () {
		itemChecker = GameObject.Find ("Equipped Item").GetComponent<EquipChecker> ();
		birdChecker = GameObject.Find ("Equipped Bird").GetComponent<EquippedBirdChecker> ();
		directionBird = GameObject.Find ("Background/Mission Panel/BirdDir");
		directionBird.SetActive (false);
	}

	public void playReq () {
		if (birdChecker.hasBird()) {
			Debug.Log ("Bird is not NULL");
			SceneManager.LoadScene(3);


		} else {
			Debug.Log ("Bird is NULL");
			directionBird.SetActive (true);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
