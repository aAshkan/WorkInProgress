using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BirdInfo : MonoBehaviour {
	[SerializeField]
	private Bird bird;
	[SerializeField]
	private string data;
	[SerializeField]
	private GameObject tooltip;
	[SerializeField]
	private GameObject birdImage;
	[SerializeField]
	private Inventory inv;
	private BirdDatabase database;

	//ProgressBar stuff
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public static float speedBar_fill;
	public static float bounceBar_fill;
	public static float healthBar_fill;
	public static float ammoBar_fill;
	public static float sizeBar_fill;
	public static float visionBar_fill;

	public Vector2 speedBar;
	public Vector2 bounceBar;
	public Vector2 healthBar;
	public Vector2 ammoBar;
	public Vector2 sizeBar;
	public Vector2 visionBar;
	public Vector2 barSize;

	void Awake(){
		speedBar = new Vector2 (Screen.width * speedBar.x, Screen.height * speedBar.y);
		bounceBar = new Vector2 (Screen.width * bounceBar.x, Screen.height * bounceBar.y);
		healthBar = new Vector2 (Screen.width * healthBar.x, Screen.height * healthBar.y);
		ammoBar = new Vector2 (Screen.width * ammoBar.x, Screen.height * ammoBar.y);
		sizeBar = new Vector2 (Screen.width * sizeBar.x, Screen.height * sizeBar.y);
		visionBar = new Vector2 (Screen.width * visionBar.x, Screen.height * visionBar.y);
		barSize = new Vector2 (Screen.width * barSize.x, Screen.height * barSize.y);
	}
	// Use this for initialization
	void Start () {
		database = GameObject.Find("BirdInventory").GetComponent<BirdDatabase> ();
		//inv = GameObject.Find ("Inventory"). GetComponent<Inventory> ();
		birdImage = GameObject.Find ("Bird Info Panel/BirdImage");
		tooltip = GameObject.Find ("Bird Info Panel/BirdInfo");
		tooltip.SetActive (false);
		birdImage.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		SetProgressBars(bird.Speed, bird.Bounce, bird.Health, bird.Ammo, bird.Size, bird.Vision);

	}
	public static void SetProgressBars(float speed, float bounce, float health, float ammo, float size, float vision){
		speedBar_fill = speed/10;
		bounceBar_fill = bounce/10;
		healthBar_fill = health/10;
		ammoBar_fill = ammo/20;
		sizeBar_fill = size/10;
		visionBar_fill = vision/10;
	}

	void OnGUI() {
		//draw the speed bar
		GUI.BeginGroup(new Rect(speedBar.x, speedBar.y, barSize.x, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, barSize.x * speedBar_fill, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		//draw the bounce bar
		GUI.BeginGroup(new Rect(bounceBar.x, bounceBar.y, barSize.x, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, barSize.x * bounceBar_fill, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		//draw the health bar
		GUI.BeginGroup(new Rect(healthBar.x, healthBar.y, barSize.x, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, barSize.x * healthBar_fill, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		//draw the ammo bar
		GUI.BeginGroup(new Rect(ammoBar.x, ammoBar.y, barSize.x, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, barSize.x * ammoBar_fill, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		//draw the size bar
		GUI.BeginGroup(new Rect(sizeBar.x, sizeBar.y, barSize.x, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, barSize.x * sizeBar_fill, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		//draw the vision bar
		GUI.BeginGroup(new Rect(visionBar.x, visionBar.y, barSize.x, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, barSize.x * visionBar_fill, barSize.y));
		GUI.Box(new Rect(0,0, barSize.x, barSize.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}
	//activate/show item info penal
	public void Activate (Bird bird) {
		this.bird = bird;
		ConstructDataString ();
		tooltip.SetActive (false);
		birdImage.SetActive (true);
	}

	//deactive/hide item info panel
	public void Deactivate() {
		tooltip.SetActive (false);
		birdImage.SetActive (false);

	}

	//modify/display item info based on which item mouse is pressed on
	public void ConstructDataString() {
		data = "Name: " + bird.Title + "\n"
			+ "Speed: " + bird.Speed + "\n"
			+ "Bounce: " + bird.Bounce + "\n"
			+ "Health: " + bird.Health + "\n"
			+ "Ammo: " + bird.Ammo + "\n"
			+ "Size: " + bird.Size + "\n"
			+ "Vision: " + bird.Vision + "\n";
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		//birdImage.GetComponent<Image> ().sprite = database.dictSprites[bird.BodySlug];
		birdImage.transform.FindChild ("Eye").GetComponent<Image> ().sprite = database.dictSprites[bird.EyeSlug];
		birdImage.transform.FindChild ("Blush").GetComponent<Image> ().sprite = database.dictSprites[bird.BlushSlug];
		birdImage.transform.FindChild ("Body").GetComponent<Image> ().sprite = database.dictSprites[bird.BodySlug];
		birdImage.transform.FindChild ("WingFront").GetComponent<Image> ().sprite = database.dictSprites[bird.WingFrontSlug];
		birdImage.transform.FindChild ("WingBack").GetComponent<Image> ().sprite = database.dictSprites[bird.WingBackSlug];
		birdImage.transform.FindChild ("Beak").GetComponent<Image> ().sprite = database.dictSprites[bird.BeakSlug];
		birdImage.transform.FindChild ("LegFront").GetComponent<Image> ().sprite = database.dictSprites[bird.LegFrontSlug];
		birdImage.transform.FindChild ("LegBack").GetComponent<Image> ().sprite = database.dictSprites[bird.LegBackSlug];
		birdImage.transform.FindChild ("Tail").GetComponent<Image> ().sprite = database.dictSprites[bird.TailSlug];
		/*birdImage.transform.FindChild ("Body").transform.position = new Vector2 (4f, 0f);
		birdImage.transform.FindChild ("WingFront").transform.position = new Vector2 (-10f,8f);
		birdImage.transform.FindChild ("Beak").transform.position = new Vector2 (21f, 3f);
		birdImage.transform.FindChild ("Legs").transform.position = new Vector2 (-8f, -15f);
		birdImage.transform.FindChild ("Tail").transform.position = new Vector2 (-18f, 3f);*/



	}
}
