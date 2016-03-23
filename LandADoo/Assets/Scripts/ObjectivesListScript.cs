using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

public class ObjectivesListScript : MonoBehaviour {

	private levelControl lvl;
	private int objCount;
	private int objNum;
	public static int index = 99;

	//making this dev friendly.
	public bool scoreLimit = false;
	public int amountToBeat;
	private int hiScoreObjNum = 0;

	public bool hitTargets = false;
	public int numToHit;
	private int hitTargetsObjNum = 0;

	public bool minimumMisses = false;
	public int chancesToMiss;
	private int minMissesObjNum = 0;

	public bool highAngle = false;
	public int highToHit;
	private int highAngleObjNum = 0;
	public static int highHitsCounter = 0;

	public bool consecutiveTargets = false;
	public int whichTarget = 0; 			//0 = nothing, 1 = cars, 2 = birds, 3 = motorcycle, 4 = civ, 5 = civ thrown obj
	public int howManyConsTargets;
	private int consTargObjNum = 0;

	public bool avoidHit = false;
	public int avoidWhat = 0; 					//0 = nothing, 1 = cars, 2 = birds, 3 = motorcycle, 4 = civ, 5 = civ thrown obj, 6 = ceiling, 7 = road
	public int avoidHowManyTimes = 0;
	private int avoidHitObjNum = 0;

	public bool hitSpecific = false;
	public int whichSpecificTarget = 0; 	//0 = nothing, 1 = cars, 2 = birds, 3 = motorcycle, 4 = civ, 5 = civ thrown obj
	public int howManySpecificTargets = 0;
	private int hitSpecificObjNum = 0;

	public bool onlyHit = false;
	public int onlyHitWhat = 0;
	private int onlyHitObjNum = 0;
	private bool comboVehicle = true;

	public bool stayUnderAboveHalf = false;
	public bool under_above = false;
	public float duration = 0.0f;
	private int stayUnderAboveHalfObjNum = 0;

	public bool testBox = false;

	string hits = "bloop";
	string touch = "blah";
	Regex rgx = new Regex ("[A]");

	void Awake(){
		DontDestroyOnLoad (this);
		objCount = 0;
		objNum = 0;


		ScoreChecker.firstObj = false;
		ScoreChecker.secondObj = false;
		ScoreChecker.thirdObj = false;

		try{
			lvl = GameObject.Find("_SCRIPTS_").GetComponent<levelControl>();
			string temp = lvl.sceneName;
			string trimmed = temp.TrimStart ("world".ToCharArray());
			string[] levelArr = trimmed.Split ('-');
			string world = levelArr [0];
			string level = levelArr [1];
			index = ((int.Parse (world)-1)*8 + (int.Parse (level)-1));
			hits = levelControl.hitString;
			touch = levelControl.touchString;
			//Debug.Log("WORKED: "+index);
			int index2 = index;
		}catch(Exception e){
			Debug.Log ("Caught Exceptiong: " + e);
		}

		//sets up the string to be displayed
		//Debug.Log("INDEX: " + index);
		switch (index) {
		case 0:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Hit 4 Targets";
			ScoreChecker.obj3string = "Miss no more than 5 times";
			break;
		case 1:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Hit 2 targets from High Angle";
			ScoreChecker.obj3string = "Hit 2 cars in a row";
			break;
		case 2:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Hit 4 objects thrown at you";
			ScoreChecker.obj3string = "Never touch the ceiling";
			break;
		case 3:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Only hit birds";
			ScoreChecker.obj3string = "Stay under half the screen for 5 seconds";
			break;
		case 4:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Hit vehicles only";
			ScoreChecker.obj3string = "Hit the motorcycle";
			break;
		case 5:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Hit 2 civilians";
			ScoreChecker.obj3string = "Dodge all objects thrown at you";
			break;
		case 6:
			ScoreChecker.obj1string = "Get a score 5 or Higher!";
			ScoreChecker.obj2string = "Don't get hit for 45 seconds";
			ScoreChecker.obj3string = "Never touch the ceiling";
			break;		
		case 7:
			ScoreChecker.obj1string = "Get a score 15 or Higher!";
			ScoreChecker.obj2string = "Hit 3 birds";
			ScoreChecker.obj3string = "Hit the yellow buggy!";
			break;
		case 99:
			ScoreChecker.obj1string = "DON'T";
			ScoreChecker.obj2string = "STOP";
			ScoreChecker.obj3string = "BELIEVINNNN'";
			break;
		}
	}

	void Update(){
		MatchCollection matches = rgx.Matches (hits);
		switch (index) {
		case 0:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;
			
			//second objective
			rgx = new Regex ("[^r]");
			matches = rgx.Matches (hits);
			if (matches.Count >= 4)
				ScoreChecker.secondObj = true;

			//third objective
			rgx = new Regex ("[r]");
			matches = rgx.Matches (hits);
			if (matches.Count <= 5)
				ScoreChecker.thirdObj = true;
			else
				ScoreChecker.thirdObj = false;
			break;
		case 1:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;

			//second objective
			if (highHitsCounter >= highToHit)
				ScoreChecker.secondObj = true;

			//third objective
			rgx = new Regex ("[C][C]");
			matches = rgx.Matches (touch);
			if (matches.Count > 0)
				ScoreChecker.thirdObj = true;
			break;
		case 2:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;

			//second objective
			rgx = new Regex ("[T]");
			matches = rgx.Matches (touch);
			if (matches.Count > 4)
				ScoreChecker.secondObj = true;
			
			//third objective
			rgx = new Regex ("[R]");
			matches = rgx.Matches (touch);
			if (matches.Count > 0)
				ScoreChecker.thirdObj = false;
			else
				ScoreChecker.thirdObj = true;
			break;
		case 3:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;
			
			//second objective
			rgx = new Regex ("[^B]");
			matches = rgx.Matches (hits);
			if (matches.Count > 0)
				ScoreChecker.secondObj = false;
			else
				ScoreChecker.secondObj = true;
			
			//third objective
			if (under_above) {
				if (BirdyScript.maxUnderTime >= duration)
					ScoreChecker.thirdObj = true;
			} else { 
				if (BirdyScript.maxAboveTime >= duration)
					ScoreChecker.thirdObj = true;
			}
			break;
		case 4:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;
			
			//second objective
			rgx = new Regex ("[^CVM]");
			matches = rgx.Matches (hits);
			if (matches.Count > 0)
				ScoreChecker.secondObj = false;
			else
				ScoreChecker.secondObj = true;

			//third objective
			rgx = new Regex ("[M]");
			matches = rgx.Matches (hits);
			if (matches.Count > 0)
				ScoreChecker.thirdObj = true;
			break;
		case 5:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;
			
			//second objective
			rgx = new Regex ("[PA]");
			matches = rgx.Matches (hits);
			if (matches.Count >= 2)
				ScoreChecker.secondObj = true;

			//third objective
			rgx = new Regex ("[T]");
			matches = rgx.Matches (touch);
			if (matches.Count > 0)
				ScoreChecker.thirdObj = false;
			else
				ScoreChecker.thirdObj = true;
			break;
		case 6:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;
			
			//second objective
			rgx = new Regex ("[CMBVT]");
			matches = rgx.Matches (touch);
			if (matches.Count > 0)
				ScoreChecker.secondObj = false;
			else
				ScoreChecker.secondObj = true;

			//third objective
			rgx = new Regex ("[R]");
			matches = rgx.Matches (touch);
			if (matches.Count > 0)
				ScoreChecker.thirdObj = false;
			else
				ScoreChecker.thirdObj = true;
			break;
		case 7:
			//first objective
			if (ScoreScript.score >= 15)
				ScoreChecker.firstObj = true;
			
			//second objective
			rgx = new Regex ("[B]");
			matches = rgx.Matches (hits);
			if (matches.Count >= 3)
				ScoreChecker.secondObj = true;

			//third objective
			rgx = new Regex ("[V]");
			matches = rgx.Matches (hits);
			if (matches.Count >= 1)
				ScoreChecker.thirdObj = true;
			break;
		case 99:
//			Debug.Log ("FUCKKKKK");
			break;
		}
	}
}
