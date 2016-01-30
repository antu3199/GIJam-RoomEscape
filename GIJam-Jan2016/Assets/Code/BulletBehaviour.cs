using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public int bounce = 0;
	public int bounceLimit = 2;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter2D (Collision col) {
		if (col.gameObject.name == "Wall" && bounce < bounceLimit) {
			//do bounce thing
		}
	}
			
			
}
