using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoopScore : MonoBehaviour {
	[SerializeField]
	public static int poop;        // The player's score.

	Text text;                      // Reference to the Text component.

	// Use this for initialization
	void Start () {
		poop = 15;
		// Set up the reference.
		text = GetComponent <Text> ();
		// Reset the score.
	}

	// Update is called once per frame
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "x" + poop;
	}
		
}
