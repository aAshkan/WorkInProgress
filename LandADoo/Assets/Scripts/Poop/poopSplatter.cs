	using UnityEngine;
using System.Collections;

public class poopSplatter : MonoBehaviour {

    public ParticleSystem ps;
	public GameObject splatter;
	bool splat = false;
	Vector2 vel = Vector2.zero;
	float randSpeed = 0.0f;

	private GameObject player;
	private bool highAngle = false;

	void Awake () {

		player = GameObject.Find ("Birdy");
		//check if this is a high angle poop
		//Debug.Log(player.transform.position.y);
		if (player.transform.position.y > 3.0f) {
			//THIS IS A HIGH ANGLE POOP
			highAngle = true;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		if (splat) {
			//create the splatter and destroy the object.
			GameObject poopGO = (GameObject)Instantiate (splatter, this.transform.position, Quaternion.identity);
			poopGO.GetComponent<poopSplatterMove> ().setXVel (randSpeed);
			Destroy(this.gameObject);
		}
		splat = false;
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		string x = "";
		if(col.gameObject.tag == "road" && col.gameObject.name != "poopsPrefab(Clone)"){
			splat = true;
			x = "r";
		}
		if (col.gameObject.tag == "Scorable" && col.gameObject.name != "poopsPrefab(Clone)") {
			splat = true;
			randSpeed = 0.0f;
			if (col.gameObject.name == "EnemyGO(Clone)") {
				randSpeed = col.gameObject.GetComponent<EnemyControl> ().getRandSpeed ();
				x = "C";
			} else if (col.gameObject.name == "BirdGO(Clone)") {
				randSpeed = col.gameObject.GetComponent<BirdControl> ().getRandSpeed ();
				x = "B";
			}
			//Debug.Log (randSpeed);
			if (highAngle)
				ObjectivesListScript.highHitsCounter++;

            //particle system!
            ParticleSystem tempGO = (ParticleSystem)Instantiate(ps, this.transform.position, Quaternion.identity);
            tempGO.Play();
		}

		levelControl.hitString += x;
	}
}
