using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public Rigidbody2D shield;
	public int mpCounter;
	float mpInc = 1f;
	int counter;
	float distanceScale;
	float shieldDis = 10f;
	Quaternion rotation;

	
	// Update is called once per frame
	void Start(){
		counter = 0;
		mpCounter = 3;
	}
	void Update () {
		posAndRotation ();
		if (GameObject.Find("Shield(Clone)") != null && counter >= mpCounter) {
			PlayerScript.mp -= mpInc;
			GameObject mpBar = GameObject.Find ("MpBar");
			MpScript mpSprite = mpBar.GetComponent<MpScript>();
			mpSprite.changeMp(PlayerScript.mp);
			counter = 0;
		} 
		if (GameObject.Find("Shield(Clone)") != null){
			counter++;
		}
		if (PlayerScript.mp <= 0) {
			Destroy (this.gameObject);
			GameObject mpBar = GameObject.Find ("MpBar");
			MpScript mpSprite = mpBar.GetComponent<MpScript>();
			mpSprite.changeMp(PlayerScript.mp);
		}
	}
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
		}
	}
	void posAndRotation(){
		Vector3 playerCoords = Camera.main.WorldToScreenPoint((Vector3)GameObject.Find ("Player").transform.position);
		float xRange = ((Input.mousePosition.x - playerCoords.x) * shieldDis) /
			Mathf.Sqrt (Mathf.Pow (Input.mousePosition.x - playerCoords.x, 2) + 
				Mathf.Pow (Input.mousePosition.y - playerCoords.y, 2));
		float yRange = ((Input.mousePosition.y - playerCoords.y) * shieldDis) /
			Mathf.Sqrt (Mathf.Pow (Input.mousePosition.x - playerCoords.x, 2) + 
				Mathf.Pow (Input.mousePosition.y - playerCoords.y, 2));
		Vector3 shieldCoords = Camera.main.ScreenToWorldPoint((new Vector3 (playerCoords.x + xRange, playerCoords.y + yRange, 10)));

		if (Input.mousePosition.y - playerCoords.y == 0) {
			if (Input.mousePosition.x - playerCoords.x >= 0) {
				rotation = Quaternion.Euler (0, 0, 180);
			} else {
				rotation = Quaternion.Euler (0, 0, 90);
			}
		} else {
			rotation = Quaternion.Euler (0, 0, 360 - (Mathf.Rad2Deg * 
				Mathf.Atan2 (Input.mousePosition.x - playerCoords.x, Input.mousePosition.y - playerCoords.y)));
		}
		if (GameObject.Find ("Shield(Clone)") != null) {
			GameObject.Find ("Shield(Clone)").transform.position = shieldCoords;
			GameObject.Find ("Shield(Clone)").transform.rotation = rotation;
		}
	}
}
