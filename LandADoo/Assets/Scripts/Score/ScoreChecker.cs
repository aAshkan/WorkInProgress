using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

/*			THIS SCRIPT MUST BE MANUALLY EDITED PER SCENE
 * 			THIS SCRIPT MUST BE MANUALLY EDITED PER SCENE
 * 			THIS SCRIPT MUST BE MANUALLY EDITED PER SCENE
*/

public class ScoreChecker : MonoBehaviour {
	//using this script as a checker for ALL objectives which will include dictating bronze, silver, gold.

	private levelControl lvl;

	//index for BSG and High Score
	int index = 0;

	//bronze, silver or gold
	public static int medal = 0;

	[SerializeField]
	private GameObject GameOver_Panel;
	public float expMult = 1.0f;
	public float expGain = 0;

	//objectives to complete.
	public static bool firstObj = false;
	public static bool secondObj = false;
	public static bool thirdObj = false;
	public bool newLevel = false;

	//Objectives in String Format
	public static string obj1string, obj2string, obj3string;

	void Awake (){
	
		//finds out what level we're at and sees if its a new level or not
		lvl = GameObject.Find("_SCRIPTS_").GetComponent<levelControl>();
		string temp = lvl.sceneName;
		string trimmed = temp.TrimStart ("world".ToCharArray());
		string[] levelArr = trimmed.Split ('-');
		string world = levelArr [0];
		string level = levelArr [1];

		index = ((int.Parse (world)-1)*8 + (int.Parse (level)-1));
		if (HiScoreScript.hScoreScript.highScoreArr [index] == 0) {
			newLevel = true;
		}
	}

	// Update is called once per frame
	void Update () {

		if (firstObj && secondObj && thirdObj)
			medal = 3;
		else if ((firstObj && secondObj) || (firstObj && thirdObj) || (secondObj && thirdObj))
			medal = 2;
		else if (firstObj || secondObj || thirdObj) 
			medal = 1;

		if (lvl.isComplete) { //if stage has completed and the player did not DIE. then rewrite the BSG and highscore scripts
			if (HiScoreScript.hScoreScript.highScoreArr [index] < ScoreScript.score) {		//if the past high score is beaten, replace it with the new one
				HiScoreScript.hScoreScript.highScoreArr [index] = ScoreScript.score;
				PlayerPrefs.SetInt (HiScoreScript.hScoreScript.highScoreArr [index].ToString (), ScoreScreen.score);
				PlayerPrefs.Save ();
			}
			if (BSG_Script.BSG.BSG_Arr [index] < medal)										//if the past medal count is beaten, replace it with the new one
				BSG_Script.BSG.BSG_Arr [index] = medal;
			//Debug.Log (firstObj + "; " + secondObj + "; " + thirdObj);
			//Debug.Log ("m: " + medal);
		}
			
	}

	void expCalc(){	
		if (ScoreScript.newHighScore) {				//if its a new high score. the exp multiplier will be 2x
			expMult = 2.0f;
		}
		if (firstObj)
			expGain += 150;							//get 150 for completing objective

		if (newLevel)
			expGain += 350; 						//static gain for having completed a NEW level
		
		expGain *= expMult;
	}

}
