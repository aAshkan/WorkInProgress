using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void  OnMouseDown() {
		SceneManager.LoadScene(1);
	}
	void PlayLandadoo() {
		SceneManager.LoadScene(1);
	}
	// Update is called once per frame
	void Update () {
	}
}
