using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	public float speed;
	public Rigidbody2D rb;
	public int mp = 50;
	public int hp = 100;
	public int damage = 10;

	public GameObject Portal;

	float Fade = 0.0f;
	bool isFading = false;

	public static bool Dead = false;

	SpriteRenderer rend;
	public GameObject Flame;
	SpriteRenderer rend2;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<SpriteRenderer> ();
		rend2 = Flame.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log ("test2");

		if (Dead == true) {
			if (isFading == true) {
				Fade += 0.02f;
				rend.GetComponent<SpriteRenderer>().color = new Color (0.0f, 0.0f, 0.0f,Fade);
				rend2.GetComponent<SpriteRenderer>().color = new Color (0.0f, 0.0f, 0.0f,Fade);
				if (Fade >= 1.0f) {
					Portal.SetActive (true);
					Portal.GetComponent<SpriteRenderer> ().enabled = false;

					isFading = false;
					Portal.GetComponent<PortalScript> ().CutsceneFadeIn ("Black");
				}
			}
		

	



		} else {

		
	
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
		}
	}
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Bullet" && Dead == false) {

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
			Debug.Log ("Game Over");
			Dead = true;
			isFading = true;
		}
	}
}
