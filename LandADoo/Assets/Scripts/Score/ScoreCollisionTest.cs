using UnityEngine;
using System.Collections;

//increments the score variable whena a colision between "scorable" tagged objects occurs.
//this was to prototype potential doo to enemy hits on score.
public class ScoreCollisionTest : MonoBehaviour {

	public Transform ParticleCollision;

	void OnCollisionEnter2D (Collision2D col)
    {
    	if(col.gameObject.tag == "Scorable"){
			
			if (col.gameObject.transform.name == "EnemyGO(Clone)") { 		//poop hits a car
				ScoreChecker.carHitCounter++;
				ScoreScript.score += 3;
				for (int i = 0; i < 3; i++){
					Instantiate (ParticleCollision, new Vector2(col.contacts[0].point.x, col.contacts[0].point.y), Quaternion.identity);
				}
			}
			if (col.gameObject.transform.name == "BirdGO(Clone)") { 		//poop hits a bird
				ScoreChecker.birdHitCounter++;
				ScoreScript.score += 1;
				for (int i = 0; i < 1; i++){
					Instantiate (ParticleCollision, new Vector2(col.contacts[0].point.x, col.contacts[0].point.y), Quaternion.identity);
				}
			}
			if (col.gameObject.transform.name == "ViCarGO(Clone)") { 		//poop hits yellow buggy
				ScoreChecker.viHitCounter++;
				ScoreScript.score += 10;
				for (int i = 0; i < 10; i++){
				Instantiate (ParticleCollision, new Vector2(col.contacts[0].point.x, col.contacts[0].point.y), Quaternion.identity);
				}
			}
			if (col.gameObject.transform.name == "MtrGO(Clone)") { 			//poop hits a motorcycle
				ScoreChecker.motorcycleHitCounter++;
				ScoreScript.score += 5;
				for (int i = 0; i < 5; i++){
					Instantiate (ParticleCollision, new Vector2(col.contacts[0].point.x, col.contacts[0].point.y), Quaternion.identity);
				}
			}
			if (col.gameObject.transform.name == "CivGO(Clone)") { 			//poop hits a civilian
				ScoreChecker.civHitCounter++;
				ScoreScript.score += 4;
				for (int i = 0; i < 4; i++){
					Instantiate (ParticleCollision, new Vector2(col.contacts[0].point.x, col.contacts[0].point.y), Quaternion.identity);
				}
			}
			if (col.gameObject.transform.name == "ThrownObjectGO(Clone)") { //poop hits a thrown object
				ScoreChecker.thrownObjectHitCounter++;
				ScoreScript.score += 2;
				for (int i = 0; i < 2; i++){
					Instantiate (ParticleCollision, new Vector2(col.contacts[0].point.x, col.contacts[0].point.y), Quaternion.identity);
				}
			}
    	}
    }
	// Update is called once per frame
	void Update () {

	}
}
