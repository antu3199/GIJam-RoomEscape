using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


	int displace = 50;
	int boxW = 100;
	int boxH = 30;
	int size = 50;

	void OnGUI () {
		// Make a background box
		//GUI.skin.label.font = GUI.skin.button.font = GUI.skin.box.font = Font;
		GUI.skin.box.fontSize = size;
		GUI.skin.box.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (displace, displace - displace / 5, Screen.width - displace * 2, 
			Screen.height - (displace * 2 - (displace / 5))), "\nGAME OVER");
		if(GUI.Button(new Rect(Screen.width / 2 - (boxW / 2), Screen.height - displace * (1 + 1), boxW, boxH), "Main Menu")) {
			SceneManager.LoadScene("Menu");
			Debug.Log ("Menu loaded");
		}
	}
}
