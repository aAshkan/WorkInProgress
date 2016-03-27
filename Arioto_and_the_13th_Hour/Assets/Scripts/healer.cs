using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class healer : characters {

	public int healAmount = 60;
	public float debuffPercentage = 0.05f;
	public int debuffTime = 4;
	//public int range;

	void Awake(){
		this.entityType = "healer";
		this.maxDamage = 0;
		//this.range = 1;
		this.counterPercentage = 0;
		//base.Awake ();
		this.pos = new position();
		findPos ();
	}

	public override void attackManager (List<GameObject> attackingTeam, List<GameObject> defendingTeam){	
		bool didHeal;  // To see if the healer has healed any ally

		didHeal = taskManager (attackingTeam, heal);
		if (!didHeal) {
			taskManager (defendingTeam, debuff);
		}
	}
	
	private delegate void task(GameObject entity);

	private bool taskManager(List<GameObject> team, task func){
		List<GameObject> finalEntities;
		GameObject entity;
		int numEntities;
		int index;
		bool success = false;
		
		finalEntities = potentialAttackees (team);
		numEntities = finalEntities.Count;
		for(int i = 0; numEntities > 0 && i < this.numAttack; ++i){
			index = (int)(Mathf.Floor(Random.value * numEntities));
			entity = finalEntities[index];
			finalEntities.RemoveAt(index);
			--numEntities;
			func (entity);
			xpManager ();
			success = true;
		}
		return success;
	}

	private void debuff(GameObject debuffee){
		characters debuffeeAtr =  debuffee.GetComponent<characters>();

		debuffeeAtr.debuffed = this.debuffTime;
		debuffeeAtr.damage = (int)(debuffeeAtr.maxDamage * (1 - this.debuffPercentage));
		//Debug.Log (debuffee.name + "'s damage: " + debuffeeAtr.damage);
	}

	private void heal(GameObject healee){
		characters healeeAtr = healee.GetComponent<characters> ();

		healeeAtr.health += this.healAmount;
		if (healeeAtr.health > healeeAtr.maxHealth)
			healeeAtr.health = healeeAtr.maxHealth;
		//else
		//	Debug.Log (healee.name + ": +" + this.healAmount);
	}

	public override bool canAttack (GameObject attackee){
		if(DistUtility.distCategorizer (this.pos, attackee.GetComponent<characters>().pos, this.range) != 0){
			return true;
		}
		return false;
	}

	public void xpManager(){
		if(this.GetComponent<playerLevelManager>() != null)
			this.GetComponent<playerLevelManager>().gainXP(this.healAmount);
	}
}