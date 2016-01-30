using UnityEngine;
using System.Collections;

public class TurretSpawner : MonoBehaviour {

	public int level;
	public int directionFrom = 90; //(in degrees)
	public GameObject Turret;

	const float RoomMinX = -7.5f;
	const float RoomMaxX = 7.5f;
	const float RoomMinY = -4.6f;
	const float RoomMaxY = -4.6f;

	Vector3 initAngleVector = Vector3.zero;

	bool isSpawning = false;

	float TurretWidth;
	float TurretHeight;


	// Use this for initialization
	void Start () {
		isSpawning = true;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (isSpawning == true) {
		//	Debug.Log ("Should have spawned");
			isSpawning = false;
			Vector3 position = Vector3.zero;
			if (directionFrom == 90) {

				Debug.Log (Turret);

				 TurretWidth = (Turret.GetComponent<SpriteRenderer> ().sprite.bounds.max.x) * 2;

				position.Set(Random.Range(RoomMinX + TurretWidth, RoomMaxX - TurretWidth), transform.position.y, 0.0f);

			}
		
			Quaternion rotation = Quaternion.identity;

			GameObject turretGameObject =  (GameObject) Instantiate(Turret, position, rotation);
			TurretScript tScript = turretGameObject.GetComponent<TurretScript> ();
			//Debug.Log ("tScript");
		
			tScript.setAnim (true, directionFrom);


		}

	}
}
