using UnityEngine;
using System.Collections;

public class CloneManager : MonoBehaviour {

	public Grid grid;

	void Awake(){
		//this.grid = new Grid (7, 10);
	}

	public void setUpTheGrid(){
		this.grid = new Grid (7, 10);

		foreach (characters c in this.gameObject.GetComponentsInChildren<characters>())
			grid.updateUnwalkableTiles (c.pos);
	}
}
