using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSpawner : MonoBehaviour {

	public int level;
	public int directionFrom = 90; //(in degrees)
	public List<GameObject> Turret = new List<GameObject>();

	const float RoomMinX = -7.5f;
	const float RoomMaxX = 7.5f;
	const float RoomMinY = -4.6f;
	const float RoomMaxY = 3.6f;

	Vector3 initAngleVector = Vector3.zero;



	bool isSpawning = false;

	float TurretWidth;
	float TurretHeight;

	int RandTurret = 0;
	// Use this for initialization
	void Start () {
		//isSpawning = true;

	}

	public void setisSpawning ( bool spawn){
		isSpawning = spawn;
	}

	public void Spawn (int randTurret){
		RandTurret = randTurret;
		isSpawning = true;

		if (isSpawning == true) {
			//	Debug.Log ("Should have spawned");
			isSpawning = false;


			//			RandTurret = Random.Range (0, 1);

			Vector3 position = Vector3.zero;
			if (directionFrom == 90) {

				TurretWidth = (Turret[RandTurret].GetComponent<SpriteRenderer> ().sprite.bounds.max.x) * 2;
				position.Set (Random.Range (RoomMinX + TurretWidth, RoomMaxX - TurretWidth), transform.position.y, 0.0f);
				//	return;

			} else if (directionFrom == 270) {
				TurretWidth = (Turret[RandTurret].GetComponent<SpriteRenderer> ().sprite.bounds.max.x) * 2;
				position.Set (Random.Range (RoomMinX + TurretWidth, RoomMaxX - TurretWidth), transform.position.y, 0.0f);
				//	return;

			} else if (directionFrom == 180) {
				TurretHeight = (Turret[RandTurret].GetComponent<SpriteRenderer> ().sprite.bounds.max.y) * 2;
				position.Set (transform.position.x ,Random.Range (RoomMinY + TurretHeight, RoomMaxY - TurretHeight) , 0.0f);
				//	return;

			}
			else if (directionFrom == 0) {
				TurretHeight = (Turret[RandTurret].GetComponent<SpriteRenderer> ().sprite.bounds.max.y) * 2;
				position.Set (transform.position.x ,Random.Range (RoomMinY + TurretHeight, RoomMaxY - TurretHeight) , 0.0f);


			}

			Quaternion rotation = Quaternion.identity;

			GameObject turretGameObject =  (GameObject) Instantiate(Turret[RandTurret], position, rotation);
			TurretScript tScript = turretGameObject.GetComponent<TurretScript> ();
			//Debug.Log ("tScript");
			tScript.setTurretType(RandTurret);
			tScript.setAnim (true, directionFrom);


		}





	}

	// Update is called once per frame
	void Update () {
	


	}
}
