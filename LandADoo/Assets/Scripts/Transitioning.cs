using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transitioning : MonoBehaviour {
    private levelControl lvl;
    void Start(){
        lvl = GameObject.Find("_SCRIPTS_").GetComponent<levelControl>();

    }

	public void toStart() {
		SceneManager.LoadScene(0);
	}
	public void goBack(){
		int previousLevel = PlayerPrefs.GetInt ("previousLevel");
		Application.LoadLevel (previousLevel);


	}
	public void toMissionBoard() {
		SceneManager.LoadScene(1);
	}
	public void toInventory (){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(2);
	}
	public void toGameScrolling(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(3);
	}
	public void toMissionTask(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(6);
	}
	public void toTutorial(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(7);
	}
	public void toBirdInventory(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(8);
	}
	public void toTurtorial(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(9);
	}
	public void to1(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(10);
	}
	public void to2(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(11);
	}
	public void to3(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(12);
	}
	public void toMissionTask2(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(13);
	}
	public void toMissionTask3(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
		SceneManager.LoadScene(14);

	}
    public void restartScene(){
		PlayerPrefs.SetInt ("previousLevel", Application.loadedLevel);
        SceneManager.LoadScene(lvl.sceneName);
		ProgressBar.SetProgressBar (0);
    }
}
