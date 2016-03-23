using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionBriefingButtons : MonoBehaviour {

	public void OnClicked(Button button)
	 {
    	 	if(button.name == "Back"){
			SceneManager.LoadScene(1);
			}
			if(button.name == "Inventory"){
			SceneManager.LoadScene(2);
			}
			if(button.name == "Play"){
			SceneManager.LoadScene(4);
			}
 	 }
}
