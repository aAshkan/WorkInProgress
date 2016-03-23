using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerUIScript : MonoBehaviour {

	private levelControl lvl;
	public Text text;

	// Use this for initialization
	void Start () {
		lvl = GameObject.Find("_SCRIPTS_").GetComponent<levelControl>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Time left: " + (lvl.timeLeft() + 1);
	}
}
