using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

	int displace = 50;
	int boxW = 100;
	int boxH = 30;
	int size = 13;

	void OnGUI () {
		// Make a background box
		//GUI.skin.label.font = GUI.skin.button.font = GUI.skin.box.font = Font;
		GUI.skin.box.fontSize = size;
		GUI.skin.box.wordWrap = true;
		GUI.skin.box.alignment = TextAnchor.UpperLeft;

		GUI.Box (new Rect (displace, displace - displace / 5, Screen.width - displace * 2,
			Screen.height - (displace * 2 - (displace / 5))), "\n\nOn no, evil people have kidnapped you and forced " +
			"you to become a sacrifice for their ritual. Try not to die by avoiding as many projectiles as you can. Once " +
			"a certain amount of time has passed, you'll be able to move onto the next stage.\n (Hint: You can activate " +
			"a shield by clicking the mouse button and moving your cursor to where you want your shield to be. Careful though " +
			"you have a limited amount of mana to cast your shield)");
		GUI.skin.box.fontSize = 20;
		GUI.skin.box.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (displace, displace - displace / 5, Screen.width - displace * 2, 
			Screen.height - (displace * 2 - (displace / 5))), "Instructions\n");

		if(GUI.Button(new Rect(Screen.width / 2 - (boxW / 2), Screen.height - displace * (1 + 1), boxW, boxH), "Main Menu")) {
			SceneManager.LoadScene("Menu");
			Debug.Log ("Menu loaded");
		}
	}
}
