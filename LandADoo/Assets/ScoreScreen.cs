using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour {
	[SerializeField]

	public static int score;   
	// The player's score.

	Text text;                      // Reference to the Text component.

	// Use this for initialization
	void Start () {
		// Set up the reference.
		//score = 0;
		score = ScoreScript.score;
		text = GetComponent <Text> ();
		// Reset the score.
	}

	// Update is called once per frame
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + score;
	}
}
