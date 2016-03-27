using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class diagonaller : characters {

	void Awake(){
		this.entityType = "diagonaller";
		//base.Awake ();
		this.pos = new position();
		findPos ();
	}

	public override void attackManager (List<GameObject> attackingTeam, List<GameObject> defendingTeam){
		List<GameObject> finalDefenders;
		GameObject attackee;
		int numDefenders;
		int index, helpers;

		finalDefenders = potentialAttackees (defendingTeam);
		numDefenders = finalDefenders.Count;
		for(int i = 0; numDefenders > 0 && i < this.numAttack; ++i){
			index = (int)(Mathf.Floor(Random.value * numDefenders));
			attackee = finalDefenders[index];
			finalDefenders.RemoveAt(index);
			--numDefenders;
			for(helpers = numHelpers (attackingTeam); helpers+1 > 0; --helpers){
				if(!countered(attackee)){
					attack (attackee);
					xpManager ();
				}
			}
		}
	}

	public void xpManager(){
		if(this.GetComponent<playerLevelManager>() != null)
			this.GetComponent<playerLevelManager>().gainXP(this.damage);
	}

	public override bool canAttack(GameObject attackee){
		if (DistUtility.isImmediateDiagonal (this.pos, attackee.GetComponent<characters>().pos))
			return true;
		return false;
	}	
}
