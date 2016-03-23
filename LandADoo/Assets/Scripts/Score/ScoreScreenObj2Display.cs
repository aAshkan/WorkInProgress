using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreenObj2Display : MonoBehaviour {

	public Text text;
	private GameObject checkbox;

	// Use this for initialization
	void Start () {
		text.text = ScoreChecker.obj2string;
		checkbox = GameObject.Find ("OutlineDoo(Clone)");
		text.transform.position = checkbox.transform.position;
		text.transform.position += new Vector3 (-80.0f, -30.0f, 0);

	}
}
