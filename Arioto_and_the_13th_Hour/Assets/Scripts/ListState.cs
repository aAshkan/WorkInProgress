using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListState {
	private static int playersCount;
	private static int enemiesCount;
	public List<playerStateNode> players;
	public List<playerStateNode> enemies;


	public ListState(){
		if (playersCount == 0)
			FindNumEntities ();
		players = new List<playerStateNode> (playersCount);
		enemies = new List<playerStateNode> (enemiesCount);
	}

	private void FindNumEntities(){
		playersCount = GameObject.FindGameObjectWithTag ("PlayerTeam").transform.childCount;
		enemiesCount = GameObject.FindGameObjectWithTag ("EnemyTeam").transform.childCount;
	}
}
