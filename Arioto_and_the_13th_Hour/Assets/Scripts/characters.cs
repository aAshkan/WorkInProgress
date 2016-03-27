using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class characters : MonoBehaviour {
	
	
	[Range(50, 1000)]  public int maxHealth = 100;
	[Range(0, 300)] public int maxDamage = 50;
	[Range(1, 3)]   public int numAttack = 1;
	[Range(0, 1)]   public float counterPercentage = 0.05f; 
	[HideInInspector] public string entityType;
	[HideInInspector] public int health;
	[HideInInspector] public int damage;
	[HideInInspector] public int debuffed;  // holds the number of turns that this entity is debuffed for
	public position pos;
	[Range(0, 2)] public int range = 1;

	/*protected virtual void Awake(){
		this.pos = new position();
		findPos ();
	}*/


	/* 
	 * maxHealth and maxDamage get initiated in 
	 * the Awake function of subclasses
	 */
	void Start(){
		this.health = this.maxHealth;
		this.damage = this.maxDamage;
		this.debuffed = 0;
		//this.pos = new position();
		//findPos ();
	}


	/* 
	 * This function decides which characters
	 * can this character attack.
	 */
	public virtual void attackManager (List<GameObject> attackingTeam, List<GameObject> defendingTeam){
		//Debug.Log ("do nothing");
	}


	/* 
	 * Checks to see if this entity can attack
	 * the object that is passed to this function.
	 */
	public virtual bool canAttack (GameObject attackee){
		//Debug.Log ("do nothing");
		return true;
	}


	/* 
	 * Attacks the object that is passed to this function.
	 */
	public void attack(GameObject attackee){
		if(attackee.activeSelf == true)
			attackee.GetComponent<characters> ().takeDamage (this.damage);
		//Debug.Log (this.name + "attacked " + attackee.name);
	}

	/*
	 * Takes damage by the amount that is 
	 * passed to this function and if its
	 * health is less than 0 this entity dies.
	 */
	public void takeDamage(int amount){
		this.health -= amount;
		//Debug.Log (this.name + ": -" + amount);
		if (health <= 0) {
			death ();
		}
	}

	/* 
	 * This function calls the function that
	 * will delete the this object from the 
	 * game manager and the also deletes the 
	 * this objects clone.
	 */
	public void death(){
		if(!this.name.EndsWith("(Clone)")){
			CreateClone.DeleteClones(this.tag, this.name);
			GetComponentInParent<gameManager> ().deleteEntity (this.gameObject);
			this.gameObject.SetActive(false);
			Destroy (this.gameObject);
		}
	}


	/* 
	 * Does the functions that has to be called
	 * after every turn.
	 */
	public void tick(){
		debuffManager ();
	}

	/*
	 * Calculates the possition of this entity.
	 */
	public void findPos(){
		this.pos.x = Mathf.RoundToInt (this.gameObject.transform.localPosition.x / 40);
		this.pos.y = Mathf.RoundToInt (this.gameObject.transform.localPosition.y / 40);
		//Debug.Log (this.name + " - X: " + this.pos.x + ", Y: " + this.pos.y);
	}

	/*
	 * If this entity is debuffed, take one 
	 * decrease the debuff and change the damage.
	 */
	private void debuffManager(){
		if (this.debuffed > 0) {
			--this.debuffed;
			if(this.debuffed == 0){
				this.damage = this.maxDamage;
			}
		}
	}

	/*
	 * returns true if this entity gets countered by the 
	 * entity that it is attacking.
	 */
	public bool countered(GameObject attackee){
		characters attackeeAtr = attackee.GetComponent<characters>();

		if (attackee.activeSelf == true) {
			if (Random.value <= attackeeAtr.counterPercentage) {
				//Debug.Log (attackee.name + " countered " + this.name);
				if (attackeeAtr.canAttack (this.gameObject)) {
					attackeeAtr.attack (this.gameObject);
				}
				return true;
			}
		}
		return false;
	}

	/*
	 * Returns a list of entities that can be 
	 * attacked by this entity.
	 */
	public List<GameObject> potentialAttackees(List<GameObject> attackees){
		List<GameObject> defenders = new List<GameObject>();
		
		foreach (GameObject attackee in attackees) {
			if(canAttack(attackee)){
				defenders.Add(attackee);
			}
		}
		return defenders;
	}

	/*
	 * Returns the number of entities that are 
	 * next to (only vertically and horizontally) 
	 * this character.
	 */
	public int numHelpers(List<GameObject> attackingTeam){
		int numHelper = 0;
		
		foreach(GameObject helper in attackingTeam){
			if (DistUtility.isNextTo(this.pos, helper.GetComponent<characters>().pos))
				++numHelper;
		}
		return numHelper;
	}
}
