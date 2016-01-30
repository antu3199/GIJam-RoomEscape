using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {

	public Sprite flameFront;
	public Sprite flameLeft;
	public Sprite flameRight;

	public float animSpeed = 1;

	SpriteRenderer rend;

	float SpriteFrame = 0.0f;


	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		SpriteFrame += animSpeed;
		if (SpriteFrame >= 0 * animSpeed && SpriteFrame < 60) {
			rend.sprite = flameFront;
		} else if (SpriteFrame >= 60  && SpriteFrame < 120 ) {
			rend.sprite = flameRight;
		} else if (SpriteFrame >= 120 && SpriteFrame < 180 ) {
			rend.sprite = flameFront;
		} else if (SpriteFrame >= 180 && SpriteFrame < 240 ) {
			rend.sprite = flameLeft;
		} else {
			rend.sprite = flameFront;
			SpriteFrame = 0;
		}

	}
}
