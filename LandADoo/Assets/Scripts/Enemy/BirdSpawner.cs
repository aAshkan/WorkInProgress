using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {

	public GameObject BirdGO;
	float maxSpawnRateInSeconds = 5f;
	public float top;
	public float bottom;
    public float birdSpeed = 0.0f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnBird", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 seconds

		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnBird() {
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject anEnemy = Instantiate (BirdGO);
		anEnemy.GetComponent<BirdControl>().setRandomSpeed(birdSpeed);
		anEnemy.transform.position = new Vector2 (max.x, Random.Range(min.y+top,min.y+bottom));

		ScheduleNextBirdSpawn ();
	}

	void ScheduleNextBirdSpawn() {
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			spawnInSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInSeconds = 1f;
		}
		Invoke ("SpawnBird", spawnInSeconds);
	}

	void IncreaseSpawnRate() {
		if (maxSpawnRateInSeconds > 1f) {
			maxSpawnRateInSeconds--;
		}
		if (maxSpawnRateInSeconds == 1f) {
			CancelInvoke ("IncreaseSpawnRate");
		}
	}
    
	public void setConstantSpeed(float x){
		//Debug.Log ("BIRDBIRDBIRD");
		birdSpeed = x;
    }
}
