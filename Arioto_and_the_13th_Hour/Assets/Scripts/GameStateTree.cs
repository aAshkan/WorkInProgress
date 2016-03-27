using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// if health is 0 or negative deactive the clone
// for heuristic if negative calculate it as 0
// if character goes to the same possition because of a differnt entity dont add it to posiotions
public class GameStateTree {
	public GameStateNode root;
	public int depth;

	public GameStateTree (int depth){
		this.depth = depth;
	}

	public void MakeTree(){
		CreateClone.SecondryUpdate ();
		root = new GameStateNode (null, CreateClone.getStates(), -1);
		/*foreach (playerStateNode p in root.entities.players)
			Debug.Log (p.pos + ", " + p.health + ", " + p.damage);
		foreach (playerStateNode p in root.entities.enemies)
			Debug.Log (p.pos + ", " + p.health + ", " + p.damage);*/
		CreateChildren (root, depth);
	}
	
	public void CreateChildren(GameStateNode state, int depth){
		if (depth == 0) {
			return;
		}

		List<playerStateNode> attackers;
		List<playerStateNode> defenders;
		state.children = new List<GameStateNode> ();
		
		CreateClone.updateHealth (state.entities, "Players");
		CreateClone.updateHealth (state.entities, "Enemies");

		if (state.enemysTurn) {
			attackers = state.entities.enemies;
			defenders = state.entities.players;
		} else {
			defenders = state.entities.enemies;
			attackers = state.entities.players;
		}


		for(int i = 0; i < attackers.Count; ++i){
			for(int j = 0; j < defenders.Count; ++j){
				List<position> possibleMoves;
				string type = CreateClone.EntityType(!state.enemysTurn, i);
				if(type == "attacker"){
					possibleMoves = attacker (CreateClone.entityRange(!state.enemysTurn, i), defenders[j].pos);
				}
				else if(type == "healler"){
					possibleMoves = healler (defenders[j].pos);
				}
				else {//if(type == "diagnoller"){
					possibleMoves = diagnoller (defenders[j].pos);
				}
				foreach(position pos in possibleMoves){
					//Debug.Log(pos);
					if(!CanGoTo(pos, ref state.entities)) continue;
					CreateClone.UpdatePos(!state.enemysTurn, i, pos);
					CreateClone.attack(!state.enemysTurn, i);
					state.children.Add(new GameStateNode (state, CreateClone.getStates(), i));
					CreateChildren(state.children[state.children.Count-1], depth-1);
					CreateClone.updateHealth (state.entities, "Players");
					CreateClone.updateHealth (state.entities, "Enemies");
				}
			}
		}
	}

	public bool isValid(position pos){
		if ((pos.x > -1 && pos.x < 7) && (pos.y > -1 && pos.y < 10)) {
			return true;
		} else
			return false;
	}


	public List<position> diagnoller(position defender){
		List<position> p = new List<position>();
		position newP = new position();

		for (int i = -1; i < 2; ++i) {
			if(i == 0) continue;
			for (int j = -1; j < 2; ++j) {
				if(j == 0) continue;
				newP.x = defender.x + i;
				newP.y = defender.y + j;
				if(isValid (newP))
					p.Add (new position(newP));
			}
		}
		return p;
	}

	public List<position> healler(position defender){
		List<position> p = new List<position>();
		position newP = new position();
		
		for (int i = -1; i < 2; ++i) {
			for (int j = -1; j < 2; ++j) {
				if (i == 0 && j == 0) continue;
				newP.x = defender.x + i;
				newP.y = defender.y + j;
				if(isValid (newP))
					p.Add (new position(newP));
			}
		}
		return p;
	}

	public List<position> attacker(int range, position defender){
		List<position> p = new List<position>();
		position newP = new position();
		
		for (int i = -1; i < 2; ++i) {
			for (int j = -1; j < 2; ++j) {
				if (Mathf.Abs(i) == Mathf.Abs(j)) continue;
				newP.x = defender.x + i*range;
				newP.y = defender.y + j*range;
				if(isValid (newP))
					p.Add (new position(newP));
			}
		}
		return p;
	}

	/*public List<position> attacker(int range, position defender){
		List<position> p = new List<position>();
		position newP = new position();

		for (int i = -1; i < 2; ++i) {
			if(i == 0) continue;
			newP.x = defender.x + i*range;
			newP.y = defender.y;
			if(isValid (newP))
				p.Add (new position(newP));
			newP.y = defender.y + i*range;
			newP.x = defender.x;
			if(isValid (newP))
				p.Add (new position(newP));
		}
		return p;
	}*/

	private bool CanGoTo(position pos, ref ListState states){
		for (int i = 0; i < states.players.Count; ++i) {
			if(pos.Equals(states.players[i].pos))
				return false;
		}
		for (int i = 0; i < states.enemies.Count; ++i) {
			if(pos.Equals(states.enemies[i].pos))
				return false;
		}
		return true;
	}
}

public class GameStateNode {
	public bool enemysTurn;
	public List<GameStateNode> children;
	public GameStateNode parent;
	public ListState entities;
	public int movedIndex;

	public GameStateNode(GameStateNode _parent, ListState state, int movedIndex){
		children = null;
		parent = _parent;
		if (parent == null)
			enemysTurn = true;
		else
			enemysTurn = !parent.enemysTurn;

		this.movedIndex = movedIndex;
		entities = state;
	
	}

	public int getEHealth(){
		int enemyTeamHealth = 0;
		foreach (playerStateNode ps in entities.enemies) {
			enemyTeamHealth += ps.health;
		}
		return enemyTeamHealth;
	}

	public int getPHealth(){
		int playerTeamHealth = 0;
		foreach (playerStateNode ps in entities.players) {
			playerTeamHealth += ps.health;
		}
		return playerTeamHealth;
	}

	public int GetTotalScore(int pHealth, int eHealth){
		int enemyTeamHealth = getEHealth ();
		int playerTeamHealth = getPHealth ();

		int less = eHealth - enemyTeamHealth;
		int more = pHealth - playerTeamHealth;
		return (1000 - less) + more;
	}

	public bool IsTerminal(){
		return (children.Count == 0 ? true : false);
	}
}
