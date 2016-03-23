using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialBox : MonoBehaviour {
public BirdyScript flap;
public Button button;

	void Start(){
			Invoke("pause", 1);
			Invoke("wake", 1);
			button.gameObject.SetActive(false);

	}

	public void onClicked() {
		resume();
		flap.FlapTheBird();
		button.gameObject.SetActive(false);

	}
	public void pause(){
	Time.timeScale = 0;
	}
	public void resume(){
	Time.timeScale =1;
	}
	void wake(){
		button.gameObject.SetActive(true);
	}
}
