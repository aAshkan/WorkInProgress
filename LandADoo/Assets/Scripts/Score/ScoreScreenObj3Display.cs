using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreenObj3Display : MonoBehaviour {
	public Text text;
	private GameObject checkbox;

	// Use this for initialization
	void Start () {
		text.text = ScoreChecker.obj3string;
		checkbox = GameObject.Find ("OutlineDoo(Clone)");
		text.transform.position = checkbox.transform.position;
		text.transform.position += new Vector3 (-80.0f, -60.0f, 0);

	}
}
