using UnityEngine;
using System.Collections;

public class position {
	public int x, y;

	public position(){
		x = -1;
		y = -1;
	}

	public position(int x, int y){
		this.x = x;
		this.y = y;
	}

	public position(position pos){
		this.x = pos.x;
		this.y = pos.y;
	}

	public bool Equals(position obj){
		return (this.x == obj.x) && (this.y == obj.y);
	}

	public override string ToString()
	{
		return  "(" + x + ", " + y + ")";
	}
}
	