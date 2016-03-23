using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialBox_drag : MonoBehaviour{
public Button button;
public Pooper pooper;

     bool     mousePressed;
     
     Vector3     mouseStartPosition;
     Vector3     mouseEndPosition;
 
     Vector3    heading;
     float    distance;
     Vector3    direction;
 
     public GameObject poops;
     public GameObject bird;
     bool goodDistance;
     
	void Start(){
			Invoke("pause", 2);
			Invoke("wake", 2);
			button.gameObject.SetActive(false);

	}

	public void onClicked() {
		
		//flap.FlapTheBird();
		

	}
	void pause(){
		Time.timeScale = 0;
	}
	void resume(){
		Time.timeScale =1;
	}
	void wake(){
		button.gameObject.SetActive(true);
	}


 
     public void down() {
 
 			print("start");
             mousePressed = true;
 
             Ray vRayStart = Camera.main.ScreenPointToRay(Input.mousePosition);
 
             mouseStartPosition = vRayStart.origin;
 	}
 
     public void up(){
     		 print("asdasd");
 			Ray vRayEnd = Camera.main.ScreenPointToRay(Input.mousePosition);

             mouseEndPosition = vRayEnd.origin;
		Debug.Log (mouseEndPosition);
		Debug.Log (mouseStartPosition);
             heading = mouseEndPosition - mouseStartPosition;
             distance = heading.magnitude;
             direction = heading/distance;

             float check = Mathf.Sqrt (Mathf.Pow (heading.x, 2f) + Mathf.Pow (heading.y, 2f));
			//Debug.Log ("Distance: " + distance);
			if (check >= 1.0){
			goodDistance = true;}
			if (mouseStartPosition.y >= mouseEndPosition.y && goodDistance) {

             var fireInstance = Instantiate(poops, bird.transform.position, Quaternion.identity) as GameObject;
             Physics2D.IgnoreCollision (fireInstance.GetComponent<Collider2D> (), bird.GetComponent<Collider2D> ());

             Vector2 direction2D = new Vector2(direction.x,direction.y);
             heading = heading.normalized;
             fireInstance.GetComponent<Rigidbody2D>().velocity =(heading * pooper.initVelocity);

             mousePressed = false;
             resume();
			 button.gameObject.SetActive(false);
			}
			else if (goodDistance) {
				Debug.Log ("shooting up against gravity?");
			} else {
				Debug.Log ("not long enough!");
				Debug.Log (check);
     }                 
	}
}
