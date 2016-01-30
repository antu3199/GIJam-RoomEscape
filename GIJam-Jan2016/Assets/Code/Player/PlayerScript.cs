using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	public hp = 100;
	public mp = 50;

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
	void OnCollisionEnter2D (collision col){
		if (col.gameObject.name == "Bullet") {
			Destroy (col.gameObject);
			hp -= 10;
		}
	}
}
