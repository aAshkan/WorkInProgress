using UnityEngine;
using System.Collections;

public class DistUtility {
		
	/*
	 * Returns true if the two passed in 
	 * possitions are next to each other.
	 */
	public static bool isNextTo(position pos1, position pos2){
		position dist;

		dist = getDistance (pos1, pos2);
		if (dist.x + dist.y == 1)
			return true;
		return false;
	}


	public static position getPos(GameObject obj){
		return (new position (Mathf.RoundToInt(obj.transform.localPosition.x / 40),
		                      Mathf.RoundToInt(obj.transform.localPosition.y / 40)));
	}

	public static bool isImmediateDiagonal(position pos1, position pos2){
		position dist;
		
		dist = getDistance (pos1, pos2);
		if (dist.x == 1 && dist.y == 1)
			return true;
		return false;
	}
	
	public static bool isInRange(position pos1, position pos2, int range){
		position dist;
		
		dist = getDistance (pos1, pos2);
		if (dist.x + dist.y == range && (dist.x == 0 || dist.y == 0))
			return true;
		return false;
	}
	
	public static int isInOneLine(position pos1, position pos2, position pos3){
		if (pos1.y == pos2.y && pos1.y == pos3.y) // if on the same row
			return 1;
		if (pos1.x == pos2.x && pos1.x == pos3.x) // if on the same column
			return 2; 
		return 0;
	}
	
	public static bool isInbetween(position pos1, position pos2, position pos3){
		int axis;
		
		if ((axis = isInOneLine(pos1, pos2, pos3)) != 0){
			if (axis == 1){
				if((pos2.x > pos1.x && pos2.x < pos3.x) || (pos2.x > pos3.x && pos2.x < pos1.x)){
					return true;
				}
			}
			else if (axis == 2){
				if((pos2.y > pos1.y && pos2.y < pos3.y) || (pos2.y > pos3.y && pos2.y < pos1.y)){
					return true;
				}
			}
		}
		return false;
	}
	
	public static int distCategorizer(position pos1, position pos2, int range){
		position dist;
		
		dist = getDistance (pos1, pos2);
		if (dist.x + dist.y == range && (dist.x == 0 || dist.y == 0)) //inRange
			return 1;
		if (dist.x == 1 && dist.y == 1) //diagonal
			return 2;
		return 0;
	}
	
	
	public static position getDistance (position pos1, position pos2){
		position dist = new position();
		
		dist.x = Mathf.Abs (pos1.x - pos2.x);
		dist.y = Mathf.Abs (pos1.y - pos2.y);
		return dist;
	}
}