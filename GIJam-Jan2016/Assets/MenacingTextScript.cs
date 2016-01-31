using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenacingTextScript : MonoBehaviour {
	string message;
	public Text TTextObject;
	float ThisTime = 0.0f;
	float SentencePause = 0.1f;
	AudioSource PlaySound;

	// Use this for initialization
	void Start () {
		PlaySound = GetComponent<AudioSource> ();

		TTextObject.text = "";
		if (GameManager.Level == 1) {
			message = "A new sacrifice for the Ritual?\nArrow keys to move";
		} else if (GameManager.Level == 2) {
			message = "Or will you be the \"The One?\" to pass?\nAim mouse to use shield";
		} else if (GameManager.Level == 3) {
			message = "Can you <S<U<R<V<I<V<E<? till the end?";
		} else if (GameManager.Level == 4) {
			message = "You must think you're so talented having made it this far\nBut let me tell you this...";
		} else if (GameManager.Level == 5) {
			message = "<Y<o<u <w<i<l<l <n<o<t <m<a<k<e <i<t <t<o <t<h<e <e<n<d<";
		} else if (GameManager.Level == 6) {
			message = "You will be yet another soul lost in the darkness";
		}else if (GameManager.Level == 7) {
			message = "Explain to me this:\nWhy is it that you try?";
		}else if (GameManager.Level == 8) {
			message = "When you have <n<o <c<h<a<n<c<e of succeeding";
		}
		else if (GameManager.Level == 9) {
			message = "What is it that gives you the determination to continue on?";
		} else if (GameManager.Level == 10) {
			message = "I do not understand.";
		}
		else if (GameManager.Level == 11) {
			message = "Give up.";
		}
		else if (GameManager.Level == 12) {
			message = "Press ESC to end the game";
		}
		else if (GameManager.Level == 13) {
			message = "Or that little X on the top right corner of the screen";
		}
		else if (GameManager.Level == 13) {
			message = "Alt-F4 works too, if you're that kind of person";
		}
		else if (GameManager.Level == 14) {
			message = "Why not take a break?";
		}
		else if (GameManager.Level == 15) {
			message = "You'll never escape this room";
		}
		else if (GameManager.Level == 16) {
			message = "Never";
		}
		else if (GameManager.Level == 17) {
			message = "Ever";
		}
		else if (GameManager.Level == 18) {
			message = "You'll never escape this room";
		}
		else if (GameManager.Level >= 19) {
			message = "I'm sorry.";
		}

	
	
		StartCoroutine (TypeText ());
	}
	
	//Types text
	IEnumerator TypeText ()
	{
		ThisTime = (Time.time);
		char[] CharArray = message.ToCharArray();

		for (int i = 0; i < CharArray.Length; i++) {
			

			string letter = CharArray[i].ToString();

			//Red
			if (letter == "<"){
				i++;
				letter = CharArray[i].ToString();
				letter = "<color=#ff0000ff>" + letter + "</color>";
			}
			//Blue
			else if (letter == ">"){
				i++;
				letter = CharArray[i].ToString();
				letter = "<color=#00ffffff>" + letter + "</color>";
			}
			//Yellow
			else if (letter == "{"){
				i++;
				letter = CharArray[i].ToString();
				letter = "<color=#ffff00ff>" + letter + "</color>";
			}

			//Advances text
			TTextObject.text += letter;
			PlaySound.Play ();

			//Limit sound frequency and play sound
			if (Time.time > ThisTime + 0.1f) {
				ThisTime = Time.time;
				GetComponent<AudioSource> ().Play ();
			}

			yield return new WaitForSeconds (SentencePause);

		


		}




		foreach (char letter in message.ToCharArray()) {


		}
	}
}
