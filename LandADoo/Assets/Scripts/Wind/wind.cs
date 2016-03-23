using UnityEngine;
using System.Collections;

public class wind : MonoBehaviour {
    
	public float strength;
	public int cardinality; //0=N and goes clockwise making 7 NW; 8 is neutral or no wind
	[SerializeField]
	private string README = "0=N and goes clockwise making 7 NW; 8 is neutral or no wind";
    static float str_static = 999;
	static int card_static = 999;

    // Use this for initialization
	void Start () {
		strength *= 0.03f;
		str_static = strength;
		card_static = cardinality;
	}

	//USED FOR SETTING WIND PURPOSES
	public void setWind(int i, float j){
		cardinality = i;
		strength = j;
	}
	public void randomWind(){
		cardinality = Random.Range (0, 7);
		strength = Random.Range (-10f, 10f);
	}

	//USED FOR UI PURPOSES
    public static float getStrength(){
		return str_static;
    }

	//USED FOR UI PURPOSES
    public static int getCard(){
		return card_static;
    }

	//USED FOR UI PURPOSES
	public static Vector2 getWindVel(){
		Vector2 v = Vector2.zero;
		switch (card_static) {
			case 0: //North
				v = new Vector2 (0, 1);
				break;
			case 1: //North East
				v = new Vector2 (1, 1);
				break;
			case 2: //East
				v = new Vector2 (1, 0);
				break;
			case 3: //South East
				v = new Vector2 (1, -1);
				break;
			case 4: //South
				v = new Vector2 (0, -1);
				break;
			case 5: //South West
				v = new Vector2 (-1, -1);
				break;
			case 6: //West
				v = new Vector2 (-1, 0);
				break;
			case 7: //North West
				v = new Vector2 (-1, 1);
				break;
			default:
				Debug.Log ("Either there's no wind or something messed up (wind.cs)");
				break;
		}
		if (str_static < 0) {
			v = v * -1 * str_static;
		} else {
			v *= str_static;
		}
		return v;
	}

}
