using UnityEngine;
using System.Collections;

public class playerStateNode {
	//public string name;
	//public string type;
	//public int index;
	public int health;
	public int damage;
	//public int range;
	public position pos;
	//public playerStateNode(string _name, string _type, int _health,
	//                       int _damage, int _range, position _pos, int _index = 0){
	public playerStateNode(int _health, int _damage, position _pos){
		//index = _index;
		//name = _name;
		//type = _type;
		health = _health;
		damage = _damage;
		//range = _range;
		pos = new position(_pos.x, _pos.y);
	}

	public playerStateNode(playerStateNode original){
		//index = original.index;
		//name = original.name;
		//type = original.type;
		health = original.health;
		damage = original.damage;
		//range = original.range;
		pos = new position(original.pos.x, original.pos.y);
	}

	public playerStateNode(GameObject obj){
		characters attr = obj.GetComponent<characters> ();

		//index = 0;
		//name = obj.name;
		health = attr.health;
		damage = attr.damage;
		//type = attr.entityType;
		//range = attr.range;
		pos = new position (attr.pos.x, attr.pos.y);
	}

	public void setPosition(position pos){
		this.pos = pos;
	}
}
