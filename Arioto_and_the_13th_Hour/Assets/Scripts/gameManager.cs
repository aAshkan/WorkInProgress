using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour{

	private List<GameObject> players;
	private List<GameObject> enemies;
	private bool playersTurn;
	[HideInInspector]
	public GameObject lastEntityMoved;
	private List<GameObject> entities;
	public Grid g;
	public AlphaBeta ai;
	[Range(1, 5)] public int diffLevel = 4;

	void Awake(){
		makingListEntities ();
		playersTurn = true;
		ai = new AlphaBeta(diffLevel);
	}

	void Start(){
		setUpPositions();
	}

	public void update()
	{
		upgradePosAndGrid ();
		lastEntityAttackMode ();
		//allAttackMode ();
		tickEntities (players);
		tickEntities (enemies);
		//levelUp (players);
		playersTurn = !playersTurn;
		WhoWon (IsGameOver ());
		if (!playersTurn && IsGameOver() == 0) {
			StartCoroutine(Wait()); 
			moveAi();
		}

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (3.0f);
	}

	void moveAi(){
		ai.FindLeaf ();
		string str = ai.entityName();
		str = str.Substring(0, str.Length-8);
		foreach(GameObject e in enemies){
			if (e.name == str){
				e.transform.position = new Vector2 (40 * ai.entityPos().x, 40 * ai.entityPos().y);
				setLastMoved(e);
				update();
			}
		}
	}

	private void tickEntities(List<GameObject> entities){
		foreach (GameObject entity in entities) {
			entity.GetComponent<characters>().tick();
		}
	}

	public void setLastMoved(GameObject lastEntityMoved){
		this.lastEntityMoved = lastEntityMoved;
	}

	public bool collisionCheck(GameObject obj){
		position pos = DistUtility.getPos (obj);

		foreach (characters c in this.gameObject.GetComponentsInChildren<characters>()) {
			if(c.pos.Equals(pos))
				return true;
		}
		return false;
	}

	private void levelUp(List<GameObject> entities){
		foreach (GameObject entity in entities) {
			entity.GetComponent<playerLevelManager>().update();
		}
	}

	public bool PlayersTurn { 
		get{return playersTurn;} 
	}

	private void setUpPositions(){
		this.g = new Grid (7, 10);

		foreach (characters c in this.gameObject.GetComponentsInChildren<characters>())
			g.updateUnwalkableTiles (c.pos);
	}
	
	public void deleteEntity(GameObject obj){
		g.updateUnwalkableTiles (obj.GetComponent<characters> ().pos);
		if (obj.tag == "Enemy")
			enemies.Remove (obj);
		else
			players.Remove (obj);
	}

	private void makingListEntities(){
		players = new List<GameObject> ();
		enemies = new List<GameObject> ();

		players.AddRange (GameObject.FindGameObjectsWithTag ("Player"));
		enemies.AddRange (GameObject.FindGameObjectsWithTag ("Enemy"));
	}

	private void upgradePosAndGrid(){
		g.updateUnwalkableTiles(lastEntityMoved.GetComponent<characters>().pos);
		lastEntityMoved.GetComponent<characters>().findPos(); //update the position of the moved entity
		g.updateUnwalkableTiles(lastEntityMoved.GetComponent<characters>().pos);
	}

	private void lastEntityAttackMode(){
		if(playersTurn)
			lastEntityMoved.GetComponent<characters> ().attackManager (players, enemies);
		else
			lastEntityMoved.GetComponent<characters> ().attackManager (enemies, players);
	}

	private void allAttackMode(){
		if (playersTurn)
			entities = players;
		else
			entities = enemies;

		foreach(GameObject entity in entities){
			if(playersTurn)
				entity.GetComponent<characters> ().attackManager (players, enemies);
			else
				entity.GetComponent<characters> ().attackManager (enemies, players);
				
		}
	}

	private int IsGameOver(){
		if (players.Count == 0)
			return 2;
		if (enemies.Count == 0)
			return 1;
		return 0;
	}

	private void WhoWon(int team){
		if (team == 1) {
			Debug.Log ("You Win!!!");
		} else if (team == 2){
			Debug.Log ("You Lose!!!");
		}
	}
}
