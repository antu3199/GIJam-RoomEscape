using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : Singleton<PlayerScript> {


	public float speed;
	public Rigidbody2D rb;
	public static float mp = 50;
	public static float hp = 100;
	public float damage = 10;
	float distanceScale;
	public GameObject shield;
	Quaternion rotation;
	int mpInc;
	public float maxMp = 50;
	float shieldMp = 10f;
	float shieldDis = 10f;
	int mpCounter;
	int counter;
	float mpRegen = 1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		mpCounter = 20;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log ("test2");

		if( Input.GetKey(KeyCode.UpArrow)){
			
			rb.AddForce (Vector2.up * speed);
		}
		if( Input.GetKey(KeyCode.DownArrow)){
			
			rb.AddForce (Vector2.down * speed);
		}
		if( Input.GetKey(KeyCode.LeftArrow)){
			
			rb.AddForce (Vector2.left * speed);
		}
		if( Input.GetKey(KeyCode.RightArrow)){
			
			rb.AddForce (Vector2.right * speed);
		}
		if(Input.GetMouseButtonDown(0)){
			if (mp >= shieldMp) {
				createShield ();
				mpFunc ();
			} else {
				Debug.Log ("No MP");
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("Bye shield.");
			destroyShield ();
		}
		if (GameObject.Find("Shield(Clone)") == null && mp < maxMp && counter >= mpCounter) {
			mp += mpRegen;
			GameObject mpBar = GameObject.Find ("MpBar");
			MpScript mpSprite = mpBar.GetComponent<MpScript> ();
			counter = 0;
			mpSprite.changeMp(mp);
		}
		if (mp < maxMp) {
			counter++;
		}
		if (GameObject.Find ("Shield(Clone)") != null) {
			counter = 0;
		}

	}
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Bullet") {

			GameObject hpBar = GameObject.Find ("HpBar");

			BulletObject bullet = col.gameObject.GetComponent<BulletObject> ();
			GuiScript hpSprite = hpBar.GetComponent<GuiScript>();
			hp -= bullet.bulletDamage;

			hpSprite.adjustHP(bullet.bulletDamage);
			checkHp ();
			Destroy (col.gameObject);
		}
	}
	void checkHp() {
		if (hp <= 0){
			SceneManager.LoadScene("Game Over");
			Debug.Log ("Game Over");
		}
	}

	void createShield(){
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
		GameObject shieldInst = Instantiate (shield, shieldCoords, rotation) as GameObject;


		//Rigidbody2D shieldInst = Instantiate(shield, shieldCoords , rotation) as Rigidbody2D; //put in actual values for position and rotation

		//changes to mp

	}

	void destroyShield(){
		GameObject sh = GameObject.Find ("Shield(Clone)");
		if (sh != null) {
			Destroy (sh);
		}
	}
	void mpFunc(){
		//check if mp should regen

		GameObject mpBar = GameObject.Find ("MpBar");
		MpScript mpSprite = mpBar.GetComponent<MpScript>();

		mpSprite.changeMp(mp);
	}

}
