using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateClone : MonoBehaviour {
	private static List<GameObject> origEnemy;
	private static List<GameObject> origPlayer;
	public static List<GameObject> enemyClones;
	public static List<GameObject> playerClones;
	
	public void Awake(){
		origEnemy = new List<GameObject> ();
		origPlayer = new List<GameObject> ();

		origPlayer.AddRange (GameObject.FindGameObjectsWithTag ("Player"));
		origEnemy.AddRange (GameObject.FindGameObjectsWithTag ("Enemy"));
		playerClones = Clone (origPlayer);
		enemyClones = Clone (origEnemy);
	}

	public List<GameObject> Clone(List<GameObject> original){
		characters atr;
		List<GameObject> clone = new List<GameObject> ();

		foreach(GameObject obj in original){
			atr = obj.GetComponent<characters>();
			switch(atr.entityType){
			case "attacker": 
				clone.Add (copyAttacker(obj));
				break;
			case "diagonaller":
				clone.Add (copyDiagonaller(obj));
				break;
			case "healer":
				clone.Add (copyHealer(obj));
				break;
			}
			clone[clone.Count-1].transform.SetParent(this.transform);
		}

		return clone;
	}

	public GameObject copyAttacker(GameObject original){
		GameObject clone = (GameObject)Instantiate (Resources.Load ("attacker"));
		attacker cloneAttr = clone.GetComponent<attacker> ();
		attacker originalAttr = original.GetComponent<attacker> ();
		copyGenericAttr (original, clone);
		cloneAttr.range = originalAttr.range;
		return clone;
	}

	public GameObject copyDiagonaller(GameObject original){
		GameObject clone = (GameObject)Instantiate (Resources.Load ("diagonaller"));
		copyGenericAttr (original, clone);
		return clone;
	}

	public GameObject copyHealer(GameObject original){
		GameObject clone = (GameObject)Instantiate (Resources.Load ("healer"));
		healer cloneAttr = clone.GetComponent<healer> ();
		healer originalAttr = original.GetComponent<healer> ();
		copyGenericAttr (original, clone);
		cloneAttr.range = originalAttr.range;
		cloneAttr.healAmount = originalAttr.healAmount;
		cloneAttr.debuffPercentage = originalAttr.debuffPercentage;
		return clone;
	}

	public void copyGenericAttr(GameObject original, GameObject clone){
		characters cloneAttr = clone.GetComponent<characters> ();
		characters originalAttr = original.GetComponent<characters> ();
		clone.name = original.name + " (Clone)";
		cloneAttr.entityType = originalAttr.entityType;
		cloneAttr.damage = originalAttr.damage;
		cloneAttr.maxDamage = originalAttr.maxDamage;
		cloneAttr.health = originalAttr.health;
		cloneAttr.maxHealth = originalAttr.maxHealth;
		cloneAttr.pos = originalAttr.pos;
		cloneAttr.numAttack = originalAttr.numAttack;
		cloneAttr.counterPercentage = 0;
	}

	public static void SecondryUpdate(){
		for(int i = 0; i < origPlayer.Count; ++i) {
			_SecondryUpdate(origPlayer[i], playerClones[i]);
		}
		for(int i = 0; i < origEnemy.Count; ++i) {
			_SecondryUpdate(origEnemy[i], enemyClones[i]);
		}
	}

	private static void _SecondryUpdate(GameObject orig, GameObject clone){
		characters cloneAttr = clone.GetComponent<characters> ();
		characters origAttr = orig.GetComponent<characters> ();

		cloneAttr.health = origAttr.health;
		cloneAttr.damage = origAttr.damage;
		cloneAttr.pos = origAttr.pos;
	}

	public static void updateHealth(ListState entities, string team){
		if (team == "Players") {
			for (int i = 0; i < playerClones.Count; ++i) {
				characters attr = playerClones [i].GetComponent<characters> ();
				attr.pos = new position (entities.players [i].pos);
				attr.health = entities.players [i].health;
				attr.damage = entities.players [i].damage;
			}
		} else if (team == "Enemies") {
			for (int i = 0; i < enemyClones.Count; ++i) {
				characters attr = enemyClones [i].GetComponent<characters> ();
				attr.pos = new position (entities.enemies [i].pos);
				attr.health = entities.enemies [i].health;
				attr.damage = entities.enemies [i].damage;
			}
		} else {
			Debug.Log (team + ": Does not exist!");
		}
	}
	
	public static void attack(bool playerTeam, int index){
		if (playerTeam) {
			playerClones [index].GetComponent<characters> ().attackManager (playerClones, enemyClones);
		} else {
			enemyClones [index].GetComponent<characters> ().attackManager (enemyClones, playerClones);
		}
	}

	public static ListState getStates(){
		ListState newL = new ListState();

		foreach (GameObject e in playerClones) {
			newL.players.Add(new playerStateNode(e));
		}
		foreach (GameObject e in enemyClones) {
			newL.enemies.Add(new playerStateNode(e));
		}
		return newL;
	}

	public static int entityRange(bool playerTeam, int index){
		if (playerTeam) {
			return playerClones [index].GetComponent<characters> ().range;
		}
		else {
			return enemyClones [index].GetComponent<characters> ().range;
		}
	}

	public static void UpdatePos(bool playerTeam, int index, position pos){
		if (playerTeam) {
			playerClones [index].GetComponent<characters> ().pos = pos;
		}
		else {
			enemyClones [index].GetComponent<characters> ().pos = pos;
		}
	}
	 
	public static string EntityType(bool playerTeam, int index){
		if (playerTeam) {
			return playerClones [index].GetComponent<characters> ().entityType;
		}
		else {
			return enemyClones [index].GetComponent<characters> ().entityType;
		}
	}

	public static void DeleteClones(string team, string name){
		int index = findIndex (team, name);
		if (team == "Enemy") {
			origEnemy.RemoveAt (index);
			enemyClones.RemoveAt (index);
		} else if (team == "Player") {
			origPlayer.RemoveAt (index);
			playerClones.RemoveAt (index);
		}
	}

	private static int findIndex(string team, string name){
		if (team == "Enemy") {
			for (int i = 0; i < origEnemy.Count; ++i) {
				if (origEnemy [i].name.Contains (name))
					return i;
			}
			return -1;
		} else if (team == "Player") {
			for (int i = 0; i < origPlayer.Count; ++i) {
				if (origPlayer [i].name.Contains (name))
					return i;
			}
			return -1;
		}
		return -1;
	}
}
