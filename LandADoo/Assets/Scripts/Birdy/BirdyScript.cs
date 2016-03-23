using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdyScript : MonoBehaviour
{

	public static BirdyScript instance;  //Accessible by other script


	//public GameObject eye;

	private CameraManager cam;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private EquippedBirdChecker equipChecker;

	[SerializeField]
	private BirdDatabase birdDatabase;

	[SerializeField]
	private GameObject mainBird;

	[SerializeField]
	private int forwardSpeed = 3;
	[SerializeField]
	private int bounceSpeed = 4;
	[SerializeField]
	private int health = 100;
	[SerializeField]
	private int ammo = 20;
	[SerializeField]
	private int ammoType = 2; //for having different poop type
	[SerializeField]
	private int vision = 10;
	[SerializeField]
	private int size = 20;

	/*private float forwardSpeedBonus;
	private float bounceSpeedBonus;
	private float healthBonus;
	private float ammoBonus;
	private int ammoTypeBonus;
	private float visionBonus;
	private float sizeBonus;*/

	[SerializeField]
	private GameObject GameOver_Panel;

	[SerializeField]
	private Button mainMenu;
	[SerializeField]
	private Button restart;


	private bool didFlap;

	public bool isAlive;

	private Button flapButton;

	//josh's variables
	private bool birdAbove = false;
	private float currentAboveTime = 0.0f;
	private float currentUnderTime = 0.0f;
	public static float maxAboveTime = 0.0f;
	public static float maxUnderTime = 0.0f;

	//  [SerializeField]
	//  private AudioSource audioSource;

	//  [SerializeField]
	//  private AudioClip flapClick, poopClip, diedClip;

	public int score;

	void Awake()
	{
		birdAbove = false;
		currentAboveTime = 0.0f;
		currentUnderTime = 0.0f;

		if (instance == null)
		{
			instance = this;
		}

		isAlive = true;
		score = 0;
		GameOver_Panel.SetActive (false);

		//AddStats (forwardSpeedBonus, bounceSpeedBonus, healthBonus, ammoBonus, ammoTypeBonus, visionBonus, sizeBonus);

		flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
		flapButton.onClick.AddListener(() => FlapTheBird());





		// SetCamerasX();
	}

	// Use this for initialization
	void Start()
	{
		cam = GameObject.Find ("Main Camera").GetComponent<CameraManager> ();
		mainBird = GameObject.Find ("Birdy");
		birdDatabase = GameObject.Find ("Bird Equipped").GetComponent<BirdDatabase> ();
		equipChecker = GameObject.Find ("Bird Equipped").GetComponent<EquippedBirdChecker> ();
		Bird bird = equipChecker.returnBird ();

		mainBird.transform.FindChild ("Eye").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.EyeSlug];
		mainBird.transform.FindChild ("Blush").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.BlushSlug];
		mainBird.transform.FindChild ("Body").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.BodySlug];
		mainBird.transform.FindChild ("WingFront").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.WingFrontSlug];
		mainBird.transform.FindChild ("WingBack").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.WingBackSlug];
		mainBird.transform.FindChild ("Beak").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.BeakSlug];
		mainBird.transform.FindChild ("Legs").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.LegsSlug];
		mainBird.transform.FindChild ("Tail").GetComponent<SpriteRenderer> ().sprite = birdDatabase.dictSprites[bird.TailSlug];

		SetStats (bird.Speed, bird.Bounce, bird.Health, bird.Ammo, bird.AmmoType, bird.Vision, bird.Size);
		cam.updateSpeed (bird.Speed);


	}

	void Update(){

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//josh's above or below equator counter
		//1.15 is equator
		if (this.transform.position.y > 1.15) {
			birdAbove = true;
			currentAboveTime += 0.02f;
		} else {
			birdAbove = false;
			currentUnderTime += 0.02f;
		}

		if (birdAbove) {
			if (maxAboveTime < currentAboveTime)
				maxAboveTime = currentAboveTime;
			currentUnderTime = 0.0f;
		} else {
			if (maxUnderTime < currentUnderTime)
				maxUnderTime = currentUnderTime;
			currentAboveTime = 0.0f;
		}

		// if (GameController.instance.//,IsGreenBirdUnlocked() )
		if (isAlive) {

			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;

			if (didFlap) {
				didFlap = false;
				myRigidBody.velocity = new Vector2 (0, bounceSpeed);
				// audioSource.PlayOneShot(flapClick);
				// anim.SetTrigger("Flap");
			}

			if (myRigidBody.velocity.y >= 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				float angle = 0;
				angle = Mathf.Lerp (0, -90, -myRigidBody.velocity.y / 7); // 7 is an arbitrary number
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}

		
			
		}

	}

	void SetCamerasX()
	{
		// might be needed to implement the vision attribute
		//Attach camera script
		// CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
	}

	void SetStats(int s, int b, int h, int a, int aT, int v, int si) {
		forwardSpeed = s;
		bounceSpeed = b;
		health = h;
		ammo = a;
		ammoType = aT; //for having different poop type
		vision = v;
		size = si;
	
	}

	/*void AddStats(float forwardSpeedBonus, float bounceSpeedBonus, float healtBonus, float ammoBonus, int ammoTypeBonus, float visionBonus, float sizeBonus) {
		forwardSpeed += forwardSpeedBonus;
		bounceSpeed += bounceSpeedBonus;
		health += healtBonus;
		ammo += ammoBonus;
		ammoType = ammoTypeBonus; //for having different poop type
		vision += visionBonus;
		size += sizeBonus;
	}*/

	public float GetPositionX()
	{
		return transform.position.x;
	}

	public void FlapTheBird()
	{
		didFlap = true;
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		string y = "";
		if (target.gameObject.tag == "road") { //falling is instant death
			isAlive = false;
			GameOver_Panel.SetActive (true);
			y = "r";
			//Game Over message
		}  

		if (target.gameObject.tag == "Scorable") { //falling is instant death
			isAlive = false;
			GameOver_Panel.SetActive (true);

			if (target.gameObject.name == "EnemyGO(Clone)") { 		//bird hits a car
				y = "C";
			}
			if (target.gameObject.name == "BirdGO(Clone)") { 		//bird hits a bird
				y = "B";
			}
			if (target.gameObject.name == "ViCarGO(Clone)") { 		//bird hits yellow buggy
				y = "V";
			}
			if (target.gameObject.name == "MtrGO(Clone)") { 		//bird hits a motorcycle
				y = "M";
			}
			if (target.gameObject.name == "CivGO(Clone)") { 		//bird hits a civilian
				y = "P";
			}
			if (target.gameObject.name == "ThrownObjectGO(Clone)") { //bird hits a thrown object
				y = "T";
				health -= 5;
			}
			//Game Over message
		}  

		if (target.gameObject.tag == "roof") { //falling is instant death
			isAlive = true;
			y = "R";
			//Game Over message
		}     
		
		if (isAlive)
		{
			//isAlive = false;
			//GameOver_Panel.SetActive (true);

			//anim.SetTrigger("Bird Died");         add animation
			//  audioSource.PlayOneShot(diedClip);    add SFXs

		}
		levelControl.touchString += y;
		//Debug.Log ("Touched: " + lastTouchObj);
	}

	void Restart() {
		Application.LoadLevel ("mainGameScroller");
	}


	void MainMenu() {
		Application.LoadLevel ("StartScreen");
	}

	/* //The whole thing is probably better off in poop script
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Car")
		{
			score++;

		}
	}

	*/ 

}

