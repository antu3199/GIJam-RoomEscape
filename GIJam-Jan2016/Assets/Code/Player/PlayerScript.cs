using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	public float speed;
	public Rigidbody2D rb;
	public int mp = 50;
	public int hp = 100;
	public int damage = 10;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
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
			Debug.Log ("Game Over");
		}
	}
}
