using UnityEngine;
using System.Collections;

public class DooSpawn : MonoBehaviour {

public Transform BronzeDoo;
public Transform SilverDoo;
public Transform GoldDoo;
public Transform OutlineDoo;

[SerializeField]
private int x1 = -5;
[SerializeField]
private int x2 = 0;
[SerializeField]
private int x3 = 5;
[SerializeField]
private float y = 0;

[SerializeField]
private int bronze = 10;
[SerializeField]
private int silver = 100;
[SerializeField]
private int gold = 200;


	// Use this for initialization
	void Start () {

		if (ScoreScreen.score < gold)
			Instantiate(OutlineDoo, new Vector3(x3, y, 0), Quaternion.identity);
		else
			Instantiate(GoldDoo, new Vector3(x3, y, 0), Quaternion.identity);
		if (ScoreScreen.score < silver)
			Instantiate(OutlineDoo, new Vector3(x2, y, 0), Quaternion.identity);
		else
			Instantiate(SilverDoo, new Vector3(x2, y, 0), Quaternion.identity);
		if (ScoreScreen.score < bronze)
			Instantiate(OutlineDoo, new Vector3(x1, y, 0), Quaternion.identity);
		else
			Instantiate(BronzeDoo, new Vector3(x1, y, 0), Quaternion.identity);

	}

	
}
