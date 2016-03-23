using UnityEngine;
using System.Collections;

public class HouseSpawner : MonoBehaviour {

	public Transform Blue_House;
	public Transform Green_House;
	public Transform Orange_House;
	public Transform Pink_House;
	public Transform Blue_House_2;
	public Transform Green_House_2;
	public Transform Orange_House_2;
	public Transform Pink_House_2;
	public Transform Blue_House_3;
	public Transform Green_House_3;
	public Transform Orange_House_3;
	public Transform Pink_House_3;
	public Transform House_Back;
	public Transform House_Back_2;
	public Transform House_Back_3;
	public Transform City_Back;
	public Transform Grass;
	public Transform Street;
	public Transform White_Fence;

	[SerializeField]
	private float height = -1.8f;
	[SerializeField]
	private float BackHouseOffset;
	[SerializeField]
	private float backHeight = -1f;
	[SerializeField]
	private float grassHeight = 2.8f;
	[SerializeField]
	private float streetHeight = 2.8f;
	[SerializeField]
	private float backgroundHouseHeight = 2.8f;
	[SerializeField]
	private float white_FenceHeight = 2.8f;


	private int num;
	private float houseSpawnRate;


	// Use this for initialization
	void Start () {
		float leftBound = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)).x;
		var xLength = Grass.GetComponent<SpriteRenderer>().bounds.size.x;
		float grassSpawnRate = (xLength / CameraManager.speed)/2;
		Instantiate (Grass, new Vector3 (leftBound + xLength/2, grassHeight, 0), Quaternion.identity);

		Invoke ("SpawnGrass", grassSpawnRate);

		//Spawn Colored Houses
		xLength = Blue_House.GetComponent<SpriteRenderer>().bounds.size.x;
		houseSpawnRate = (xLength / CameraManager.speed);
		Invoke ("SpawnHouse", houseSpawnRate);
		for (var i = (Camera.main.ViewportToWorldPoint(new Vector2 (0,0)).x + (xLength/2)); i < (Camera.main.ViewportToWorldPoint(new Vector2 (1, 1)).x + (1.5f *xLength)); i+= xLength) {
			num = Random.Range (1, 13);
			if (num == 1) {
				Instantiate (Blue_House, new Vector3 (i, height-.06f, 0), Quaternion.identity);
			} else if (num == 2) {
				Instantiate (Green_House, new Vector3 (i, height-.06f, 0), Quaternion.identity);
			} else if (num == 3) {
				Instantiate (Orange_House, new Vector3 (i, height-.06f, 0), Quaternion.identity);
			} else if (num == 4) {
				Instantiate (Pink_House, new Vector3 (i, height-.06f, 0), Quaternion.identity);
			} else if ( num == 5){
				Instantiate (Blue_House_2, new Vector3 (i, height, 0), Quaternion.identity);
			} else if (num == 6) {
				Instantiate (Green_House_2, new Vector3 (i, height, 0), Quaternion.identity);
			} else if (num == 7) {
				Instantiate (Orange_House_2, new Vector3 (i, height, 0), Quaternion.identity);
			} else if (num == 8) {
				Instantiate (Pink_House_2, new Vector3 (i, height, 0), Quaternion.identity);
			} else if ( num == 9){
				Instantiate (Blue_House_3, new Vector3 (i, height, 0), Quaternion.identity);
			} else if (num == 10) {
				Instantiate (Green_House_3, new Vector3 (i, height, 0), Quaternion.identity);
			} else if (num == 11) {
				Instantiate (Orange_House_3, new Vector3 (i, height, 0), Quaternion.identity);
			} else if (num == 12) {
				Instantiate (Pink_House_3, new Vector3 (i, height, 0), Quaternion.identity);
			}
		}	
		for(var j = (Camera.main.ViewportToWorldPoint(new Vector2 (0,0)).x + (xLength/2)); j < (Camera.main.ViewportToWorldPoint(new Vector2 (1, 1)).x + (xLength * 1.5f)); j+= xLength) {
			num = Random.Range (1, 4);
			xLength = House_Back.GetComponent<SpriteRenderer>().bounds.size.x;
			houseSpawnRate = (xLength / (CameraManager.speed - GrayHouseMover.speed));
			//Spawn Background Houses
			if (num == 1)
				Instantiate (House_Back, new Vector3 (j - BackHouseOffset , backgroundHouseHeight), Quaternion.identity);
			else if (num == 2)
				Instantiate (House_Back_2, new Vector3 (j - BackHouseOffset , backgroundHouseHeight), Quaternion.identity);
			else if (num == 3)
				Instantiate (House_Back_3, new Vector3 (j - BackHouseOffset , backgroundHouseHeight), Quaternion.identity);
		}
		ScheduleNextHouse_BackSpawn();

		ScheduleNextFenceSpawn();
		//float fenceSpawnRate;
		xLength = White_Fence.GetComponent<SpriteRenderer>().bounds.size.x;
		for(float j = (Camera.main.ViewportToWorldPoint(new Vector2 (0,0)).x + xLength/2); j < (Camera.main.ViewportToWorldPoint(new Vector2 (1, 1)).x + 1.5 * xLength); j += xLength){
			//fenceSpawnRate = (xLength / (CameraManager.speed - FenceMover.speed));
			Instantiate (White_Fence, new Vector2 (j, white_FenceHeight), Quaternion.identity);
		}

		//Spawn City
		xLength = City_Back.GetComponent<SpriteRenderer>().bounds.size.x;
		float citySpawnRate;
		if(CameraManager.speed - CityMover.speed > 0){
			citySpawnRate = (xLength / (CameraManager.speed - CityMover.speed))/2;
			Invoke("SpawnCity", citySpawnRate);
		}

		Instantiate (City_Back, new Vector3 (leftBound+36, backHeight, 0), Quaternion.identity);

		//Spawn Street
		xLength = Street.GetComponent<SpriteRenderer>().bounds.size.x;
		float streetSpawnRate = (xLength / (CameraManager.speed - StreetGarbageCollector.speed));

		Instantiate (Street, new Vector3 (leftBound+(xLength/2), streetHeight, 0), Quaternion.identity);
		Instantiate (Street, new Vector3 (leftBound+(xLength * 1.5f), streetHeight, 0), Quaternion.identity);
		Invoke("SpawnStreet", streetSpawnRate);

	}
	//Continue to spawn houses/background
	void SpawnHouse() {
		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		float xLength = Blue_House.GetComponent<SpriteRenderer>().bounds.size.x;
		//random to determine house
		num = Random.Range (1, 13);
		//BACKGROUND HOUSES
		//REGULAR FUCKIN HOUSES
		if (num == 1) {
			Instantiate (Blue_House, new Vector2 (max.x + (xLength/2), height-.06f), Quaternion.identity);
		}else if (num == 2) {
			Instantiate (Green_House, new Vector2 (max.x + (xLength/2), height-.06f), Quaternion.identity);
		} else if (num == 3) {
			Instantiate (Orange_House, new Vector2 (max.x + (xLength/2), height-.06f), Quaternion.identity);
		} else if (num == 4) {
			Instantiate (Pink_House, new Vector2 (max.x + (xLength/2), height-.06f), Quaternion.identity);
		} else if (num == 5) {
			Instantiate (Blue_House_2, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		} else if (num == 6) {
			Instantiate (Green_House_2, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		} else if (num == 7) {
			Instantiate (Orange_House_2, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		}else if (num == 8) {
			Instantiate (Pink_House_2, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		} else if (num == 9) {
			Instantiate (Blue_House_3, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		} else if (num == 10) {
			Instantiate (Green_House_3, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		} else if (num == 11) {
			Instantiate (Orange_House_3, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		} else if (num == 12) {
			Instantiate (Pink_House_3, new Vector2 (max.x + (xLength/2), height), Quaternion.identity);
		}




		ScheduleNextHouseSpawn(); 
	}
	void ScheduleNextHouseSpawn() {
		var xLength = Blue_House.GetComponent<SpriteRenderer>().bounds.size.x;
		houseSpawnRate = (xLength / CameraManager.speed);
		Invoke("SpawnHouse", (houseSpawnRate));

	}
	void SpawnCity() {
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		Instantiate (City_Back, new Vector2 (max.x, backHeight), Quaternion.identity);
		ScheduleNextCitySpawn ();
	}
	void ScheduleNextCitySpawn() {
		var xLength = City_Back.GetComponent<SpriteRenderer>().bounds.size.x;
		float citySpawnRate = (xLength / (CameraManager.speed - CityMover.speed))/2;
		Invoke("SpawnCity", citySpawnRate);
	}
	void SpawnGrass() {
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		var xLength = Grass.GetComponent<SpriteRenderer>().bounds.size.x;
		Instantiate (Grass, new Vector3 (max.x + xLength/2, grassHeight, 0), Quaternion.identity);
		ScheduleNextGrassSpawn();
	}
	void ScheduleNextGrassSpawn() {
		var xLength = Grass.GetComponent<SpriteRenderer>().bounds.size.x;
		float grassSpawnRate = (xLength / CameraManager.speed)/2;
		Invoke("SpawnGrass", grassSpawnRate);
	}
	void SpawnStreet() {
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		var xLength = Street.GetComponent<SpriteRenderer>().bounds.size.x;
		Instantiate (Street, new Vector3 (max.x + xLength/2, streetHeight, 0), Quaternion.identity);
		ScheduleNextStreetSpawn();
	}
	void ScheduleNextStreetSpawn() {
		var xLength = Street.GetComponent<SpriteRenderer>().bounds.size.x;
		float streetSpawnRate = (xLength / (CameraManager.speed - StreetGarbageCollector.speed));
		Invoke("SpawnStreet", (streetSpawnRate - .03f)); // subtracting epsilon value for fluidity
	}
	void SpawnHouse_Back() {
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		float xLength = House_Back.GetComponent<SpriteRenderer>().bounds.size.x;
		//random to determine house
		var num = Random.Range (1, 4);
		//BACKGROUND HOUSES
		if (num == 1)
			Instantiate (House_Back, new Vector2 (max.x + (xLength/2) -BackHouseOffset, backgroundHouseHeight), Quaternion.identity);
		else if (num == 2)
				Instantiate (House_Back_2, new Vector2 (max.x + (xLength/2) -BackHouseOffset, backgroundHouseHeight), Quaternion.identity);
		else if (num == 3)
				Instantiate (House_Back_3, new Vector2 (max.x + (xLength/2) -BackHouseOffset, backgroundHouseHeight), Quaternion.identity);

		//REGULAR FUCKIN HOUSES
		ScheduleNextHouse_BackSpawn();
	}
	void ScheduleNextHouse_BackSpawn() {
		var xLength = House_Back.GetComponent<SpriteRenderer>().bounds.size.x;
		float houseSpawnRate = (xLength / (CameraManager.speed - GrayHouseMover.speed));
		Invoke("SpawnHouse_Back", (houseSpawnRate )); // subtracting epsilon value for fluidity
	}

	void SpawnFence() {
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		var xLength = White_Fence.GetComponent<SpriteRenderer>().bounds.size.x;
		Instantiate (White_Fence, new Vector2 (max.x +xLength, white_FenceHeight), Quaternion.identity);
		ScheduleNextFenceSpawn();
	}

	void ScheduleNextFenceSpawn() {
		var xLength = White_Fence.GetComponent<SpriteRenderer>().bounds.size.x;
		float fenceSpawnRate = (xLength / (CameraManager.speed));
		Invoke("SpawnFence", (fenceSpawnRate)); // subtracting epsilon value for fluidity
	}



}