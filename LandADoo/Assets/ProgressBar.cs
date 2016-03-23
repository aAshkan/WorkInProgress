using UnityEngine;
 using System.Collections;
 
 public class ProgressBar : MonoBehaviour {
     public static float barDisplay; //current progress
    // public Vector2 target = new Vector2(20,40);
     //public Vector2 target_size = new Vector2(60,20);
     public Vector2 target;
     public Vector2 target_size;
     public Texture2D emptyTex;
     public Texture2D fullTex;

     void Awake(){
     target = new Vector2(Screen.width * target.x, Screen.height * target.y);
     target_size = new Vector2(Screen.width*target_size.x, Screen.height*target_size.y);
     }

     void OnGUI() {
         //draw the background:
         GUI.BeginGroup(new Rect(target.x, target.y, target_size.x, target_size.y));
             GUI.Box(new Rect(0,0, target_size.x, target_size.y), emptyTex);
         
             //draw the filled-in part:
             GUI.BeginGroup(new Rect(0,0, target_size.x * barDisplay, target_size.y));
                 GUI.Box(new Rect(0,0, target_size.x, target_size.y), fullTex);
             GUI.EndGroup();
         GUI.EndGroup();
     }
     
     void Update() {
         //for this example, the bar display is linked to the current time,
         //however you would set this value based on your desired display
         //eg, the loading progress, the player's health, or whatever.
 //        barDisplay = MyControlScript.staticHealth;
     }
     public static void SetProgressBar(float amount)
     {
     	barDisplay = amount;
     }
 }