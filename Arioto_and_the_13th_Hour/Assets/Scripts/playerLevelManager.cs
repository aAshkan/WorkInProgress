using UnityEngine;
using System.Collections;

public class playerLevelManager : MonoBehaviour {
	public int XP = 0;
	public int level = 0;
	private int maxXP = 1000;
	private int maxLevel = 20;
	public bool justLeveled = false;

	void Awake(){
		// load levels and xp and calculate the player atrribute
	}

	void Start(){

	}

	public virtual void calcAttribute(){

	}

	public void update(){
		if (justLeveled) {
			justLeveled = false;
			calcAttribute ();
		}
	}

	public void gainXP(int amount){
		if (this.level != this.maxLevel) {
			this.XP += amount;
			if(this.XP / this.maxXP != 0)
				justLeveled = true;
			this.level += this.XP / this.maxXP;
			if (this.level > this.maxLevel)
				this.level = this.maxLevel;
			this.XP %= this.maxXP;
		}
	}
}
