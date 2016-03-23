using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class windUI : MonoBehaviour {


    UnityEngine.UI.Text windText;
	static float blah;
	float str_ = wind.getStrength();
	int card_ = wind.getCard();
	bool windChanged = false;

    // Use this for initialization
	void Start (){
		str_ = wind.getStrength();
		card_ = wind.getCard();
		ChangeUI ();
	}

	// Update is called once per frame
	void Update () {
		if (str_ != wind.getStrength ()) {
			windChanged = true;
		}
		if (card_ != wind.getCard ()) {
			windChanged = true;
		}

		if (windChanged) {
			ChangeUI ();
		}
	}

	void ChangeUI(){
		string dir = "";
		float hold_str = str_;
		str_ *= 100f;
		str_ = Mathf.Round(str_);
		windText = GetComponent<Text> ();

		if (card_ == 8 || str_ == 0) {
			dir = "No Wind";
			windText.text = dir;
		} 
		else {
			switch (card_) {
			case 0: //North
				dir = "North";
				break;
			case 1: //North East
				dir = "North East";
				break;
			case 2: //East
				dir = "East";
				break;
			case 3: //South East
				dir = "South East";
				break;
			case 4: //South
				dir = "South";
				break;
			case 5: //South West
				dir = "South West";
				break;
			case 6: //West
				dir = "West";
				break;
			case 7: //North West
				dir = "North West";
				break;
			default:
				Debug.Log ("Either there's no wind or something messed up (windUI.cs)");
				break;
			}
			if (str_ < 0) {
				str_ *= -1;
			}
			windText.text = "Wind Strength: " + str_ + "; Wind Direction: " + dir;
		}

		windChanged = false;
		str_ = hold_str;
	}
}
