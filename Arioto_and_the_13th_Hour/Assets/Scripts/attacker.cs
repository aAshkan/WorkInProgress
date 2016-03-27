using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class attacker : characters {
	//[Range(1, 2)] public int range = 1;
	
	void Awake(){
		this.entityType = "attacker";
		//base.Awake ();
		this.pos = new position();
		findPos ();
	}

	public override void attackManager (List<GameObject> attackingTeam, List<GameObject> defendingTeam){
		List<GameObject> helpers, attackees;
		GameObject tempHelper = null, finalAttackee = null, finalHelper = null;
		int highestDamage = 0, tempDamage = 0;
		int index;
		int numhelpers;

		attackees = potentialAttackees (defendingTeam);
		for (int i = 0; attackees.Count > 0 && i < numAttack; ++i) {
			foreach (GameObject attackee in attackees) {
				helpers = checkForHelpers (attackingTeam, attackee);
				tempDamage = chooseTheBestHelper (helpers, ref tempHelper);
				if (highestDamage < tempDamage) {
					highestDamage = tempDamage;
					finalHelper = tempHelper;
					finalAttackee = attackee;
				}
			}
			if (finalHelper == null) {				// if no helper found
				index = (int)(Mathf.Floor (Random.value * attackees.Count));
				finalAttackee = attackees [index];
			} 
			else {
				if (!finalHelper.GetComponent<characters>().countered (finalAttackee)) {
					finalHelper.SendMessage ("attack", finalAttackee);
					finalHelper.SendMessage ("xpManager");
				}
			}
			for(numhelpers = numHelpers (attackingTeam); numhelpers+1 > 0; --numhelpers){
				if (finalAttackee && !countered (finalAttackee)) {
					attack (finalAttackee);
					xpManager ();
				}
			}
			attackees.Remove(finalAttackee);
			finalHelper = null;
		}
	}

	public void xpManager(){
		if(this.GetComponent<playerLevelManager>() != null)
			this.GetComponent<playerLevelManager>().gainXP(this.damage);
	}

	public override bool canAttack(GameObject attackee){
		characters a = attackee.GetComponent<characters> ();

		if (DistUtility.isInRange (this.pos, a.pos, this.range))
			return true;
		return false;
	}

	private List<GameObject> checkForHelpers(List<GameObject> helpingEntities, GameObject defendingPlayer){
		characters helperAtr;
		List<GameObject> helpers = new List<GameObject>();
		position defenderPos = defendingPlayer.GetComponent<characters> ().pos;

		foreach(GameObject helpingEntity in helpingEntities){
			helperAtr = helpingEntity.GetComponent<characters>();
			if(helpingEntity != this.gameObject && helperAtr.entityType == "attacker"){
				if(DistUtility.isInbetween(this.pos, defenderPos, helperAtr.pos)){
					if(helperAtr.canAttack(defendingPlayer)){
						helpers.Add(helpingEntity);
					}
				}
			}
		}
		return helpers;
	}

	private int chooseTheBestHelper(List<GameObject> helpers, ref GameObject bestHelper){
		GameObject bestEntity = null;
		int highestDamage = 0, tempDamage;

		if(helpers.Count > 0){
			for(int i = 0; i < helpers.Count; ++i){
				tempDamage = helpers[i].GetComponent<characters>().damage;
				if(highestDamage < tempDamage){
					bestEntity = helpers[i];
					highestDamage = tempDamage;
				}
			}
		}

		bestHelper = bestEntity;
		return highestDamage;
	}
}
