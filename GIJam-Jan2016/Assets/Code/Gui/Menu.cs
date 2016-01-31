using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	int displace = 50;
	int boxW = 100;
	int boxH = 30;


	void OnGUI () {


		if(GUI.Button(new Rect(Screen.width / 2 - (boxW / 2), Screen.height - displace * (1 + 0), boxW, boxH), "Start Game")) {
			SceneManager.LoadScene("LevelRoom");
			GameManager.Level = 1;
		
			Debug.Log ("Load level 1");
		}

	}
}
