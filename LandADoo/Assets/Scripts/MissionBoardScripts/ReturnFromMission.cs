using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnFromMission : MonoBehaviour {
	
	public void missionButtonClicked() {

		SceneManager.LoadScene(0);

	}
}
