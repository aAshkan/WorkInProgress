using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreenObj1Display : MonoBehaviour {

	public Text text;
	private GameObject checkbox;

	// Use this for initialization
	void Start () {
		text.text = ScoreChecker.obj1string;
		checkbox = GameObject.Find ("OutlineDoo(Clone)");
		text.transform.position = checkbox.transform.position;
		text.transform.position += new Vector3 (-80.0f, 0, 0);

	}
}
