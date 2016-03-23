using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	[SerializeField]
    public static int score;   
	// The player's score.

	private levelControl lvl;
	public static bool newHighScore = false;
    Text text;                      // Reference to the Text component.

	// Use this for initialization
	void Start () {
	        // Set up the reference.
		lvl = GameObject.Find("_SCRIPTS_").GetComponent<levelControl>();
		score = 0;

        text = GetComponent <Text> ();
		newHighScore = false;
	}
	
	// Update is called once per frame
    void Update ()
    {
		string temp = lvl.sceneName;
		string trimmed = temp.TrimStart ("world".ToCharArray());
		string[] levelArr = trimmed.Split ('-');
		string world = levelArr [0];
		string level = levelArr [1];

		int index = 0;
		index = ((int.Parse (world)-1)*8 + (int.Parse (level)-1));

		text.text = "Score: " + score + "; High Score: "+ PlayerPrefs.GetInt(HiScoreScript.hScoreScript.highScoreArr [index].ToString (), 0);


		if (score >= HiScoreScript.hScoreScript.highScoreArr [index]) {
			newHighScore = true;
		}

    }
}
