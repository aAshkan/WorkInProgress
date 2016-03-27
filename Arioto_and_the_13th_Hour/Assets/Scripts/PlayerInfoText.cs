using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfoText : MonoBehaviour {
	int health;
	int numAttack;
	int damage;
	characters parent;
	string type;
	Text instruction;

	// Use this for initialization
	void Start (){
		instruction = GetComponent<Text>();
		parent = GetComponentInParent<characters> ();
		numAttack = parent.numAttack;
		type = parent.entityType.ToUpper().Substring(0, 1) + parent.range;
		//Debug.Log (parent.entityType [0]);
	}
	
	// Update is called once per frame
	void Update () {
		health = parent.health;
		damage = parent.damage;
		instruction.text = type + "\n" + health + "\n" + damage + "-" + numAttack;
	}
}

