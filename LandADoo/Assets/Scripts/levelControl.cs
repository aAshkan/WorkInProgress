using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class levelControl : MonoBehaviour {

    public static levelControl Instance;
    public string sceneName;
	public bool isComplete = false;
	public bool gameOver = false;
	public static bool loadMissionTask = true;

    public GameObject carSpawner;
    public GameObject birdSpawner;
    public GameObject civSpawner;
    public GameObject mtrcycleSpawner;
    public GameObject windGO;

    [SerializeField]
    private GameObject GameOver_Panel;

	private float time;
	private float timeLimit = 120; //2 minutes
    /*
        controlString = "S/S/O/S/X/X"
        need to delimit by "/"
    */
    public string controlString;
    private string[] controlArr = new string[6];

	public static string hitString;
	public static string touchString;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(GameObject.Find("persistentScripts").GetComponent<ObjectivesListScript>());
		hitString = "";
		touchString = "";

		if (loadMissionTask)
			SceneManager.LoadScene ("MissionTask");
	}
	void Start () {
        Debug.Log("Name: " + sceneName);

        controlArr = controlString.Split('/');
        editCarSpawner      (controlArr[0]);
        editBirdSpawner     (controlArr[1]);
        editCivSpawner      (controlArr[2]);
        editMtrcycleSpawner (controlArr[3]);
        editWind            (controlArr[4]);
        editTime            (controlArr[5]);
    }
	
    void FixedUpdate(){
        if (timesUp() && !gameOver){
			//GameOver_Panel.SetActive(true);
			isComplete = true;
			SceneManager.LoadScene("ScoreScreen");
        }
    }

    void editCarSpawner(string c){
        float x = 0.0f;
        if (c != "O"){                  //speed is constant
            x = float.Parse(c);
        }
        carSpawner.GetComponent<EnemySpawner>().setConstantSpeed(x);
    }

    void editBirdSpawner(string c){
		float x = 0.0f;
		if (c == "X") {						//no birds
			birdSpawner.SetActive(false);
		}						
		else if (c != "O"){                  //speed is constant
			x = float.Parse(c);
			birdSpawner.GetComponent<BirdSpawner>().setConstantSpeed(x);
		}
    }

    void editCivSpawner(string c){
		int x = 0;
		if (c == "O") 									//passive walking pedestrian
			x = 1;
		else if (c == "A") 								//angry walking pedestrian
			x = 2;
		else if (c == "X") 								//no pedestrian
			x = 3;
		else											//invalid, shouldn't happen.
			Debug.Log ("Invalid input for Civilians");

		//civSpawner.GetComponent<CivSpawner>().setCivMode(x);
    }

    void editMtrcycleSpawner(string c){

    }

    void editWind(string c){
		if (c == "O") {											//IF WIND IS 'O'
			windGO.GetComponent<wind> ().randomWind ();
		} else if (c != "X") {										//if there IS wind
			int tempInt = 8;
			string[] temp = new string[2];
			temp = c.Split ('.');
			//temp[0] should be Cardinality
			switch (temp [0]) {
			case "N":
				tempInt = 0;
				break;
			case "NE":
				tempInt = 1;
				break;
			case "E":
				tempInt = 2;
				break;
			case "SE":
				tempInt = 3;
				break;
			case "S":
				tempInt = 4;
				break;
			case "SW":
				tempInt = 5;
				break;
			case "W":
				tempInt = 6;
				break;
			case "NW":
				tempInt = 7;
				break;
			default:
				Debug.Log ("Something went wrong in switch statement!");
				break;
			}
			//temp[1] should be Strength
			float tempFloat = float.Parse (temp [1]);
			windGO.GetComponent<wind> ().setWind (tempInt, tempFloat);
		} else if (c == "X") {
			windGO.GetComponent<wind> ().setWind (0, 0);
		}
			
    }

	public int timeLeft(){
		return (int)(timeLimit - time);
	}

    void editTime(string c){
		if (c != "X") {
			timeLimit = float.Parse(c);
			Debug.Log("Time Limit: " + timeLimit);
		}
    }

    bool timesUp(){
        time += Time.deltaTime;
        if (time >= timeLimit)
            return true;
        return false;
    }
}
