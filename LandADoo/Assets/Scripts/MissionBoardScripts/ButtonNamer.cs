using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonNamer : MonoBehaviour {
	public int world;
	public static int worldStatic;
	public static int levelIndexStatic;
	void Awake(){
		worldStatic = world;
	}
	public void OnClicked(Button button)
	 {
		switch (button.name) {
			case "Button (1)":
				levelIndexStatic = 0 + ((world-1)*8);
				break;
			case "Button (2)":
				levelIndexStatic = 1 + ((world-1)*8);
				break;
			case "Button (3)":
				levelIndexStatic = 2 + ((world-1)*8);
				break;
			case "Button (4)":
				levelIndexStatic = 3 + ((world-1)*8);
				break;
			case "Button (5)":
				levelIndexStatic = 4 + ((world-1)*8);
				break;
			case "Button (6)":
				levelIndexStatic = 5 + ((world-1)*8);
				break;
			case "Button (7)":
				levelIndexStatic = 6 + ((world-1)*8);
				break;
			case "Button (8)":
				levelIndexStatic = 7 + ((world-1)*8);
				break;
			default:
				Debug.LogError ("Something wrong in switch");
				break;
		}
		string temp = "world";
		temp += (worldStatic.ToString() + "-" + (levelIndexStatic+1).ToString());
		SceneManager.LoadScene(temp);
		/*
    	 	if(button.name == "Button (1)"){
			SceneManager.LoadScene(6);
			}
			if(button.name == "Button (2)"){
			SceneManager.LoadScene(9);
			}
			if(button.name == "Button (3)"){
			SceneManager.LoadScene(10);
			}
			if(button.name == "Button (4)"){
			SceneManager.LoadScene(11);
			}
			if(button.name == "Button (5)"){
			SceneManager.LoadScene(12);
			}
			if(button.name == "Button (6)"){
			SceneManager.LoadScene(13);
			}
			if(button.name == "Button (7)"){
			SceneManager.LoadScene(14);
			}
			if(button.name == "Button (8)"){
			SceneManager.LoadScene(15);
			}
			*/
 	 }
}
