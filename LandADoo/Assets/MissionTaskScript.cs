using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionTaskScript : MonoBehaviour {

	public Text title;
	public Text missions;
	// Use this for initialization
	void Awake () {
		int world = ButtonNamer.worldStatic;
		int level = ButtonNamer.levelIndexStatic % 8;
		levelControl.loadMissionTask = false;
		switch (world) {
		case 1:						//SAN FRANCISCO
			title.text = "San Francisco\n Stage " + (level+1).ToString();
			break;
		case 2:
			title.text = "New York\n Stage " + (level + 1).ToString ();
			break;
		case 3:
			break;
		}

		string tempString = "";
		tempString = ScoreChecker.obj1string + "\n" + ScoreChecker.obj2string + "\n" + ScoreChecker.obj3string;
		missions.text = tempString;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
