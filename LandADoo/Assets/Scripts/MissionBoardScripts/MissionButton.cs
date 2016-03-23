using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MissionButton : MonoBehaviour {

	// Use this for initialization

	public void onClick(){
		 	SceneManager.LoadScene(1);
	}
}
