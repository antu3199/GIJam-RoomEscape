using UnityEngine;
using System.Collections;

/// <summary>
/// Ubh bullet.
/// This is the primary physics stuff is in.
/// </summary>
public class BulletObject : MonoBehaviour
{
	public int bulletDamage = 10;


	void Update(){
		if (GameManager.StopAllBullets == true) {

			StopAllCoroutines ();
			transform.position = Vector3.zero;
			transform.localPosition = Vector3.zero;
			transform.rotation =  Quaternion.identity;
			transform.localRotation =  Quaternion.identity;
		}

	}



	/// <summary>
	/// Bullet Shot
	/// </summary>
	/// 

	public void Shot (float speed, float angle, float accelSpeed, float accelTurn,
		bool homing, Transform homingTarget, float homingAngleSpeed,
		bool wave, float waveSpeed, float waveRangeSize)
	{

		if (GameManager.StopAllBullets == false) {
			
			if (gameObject.activeInHierarchy == false) {
				return;
			}

			StartCoroutine (MoveCoroutine (speed, angle, accelSpeed, accelTurn,
				homing, homingTarget, homingAngleSpeed,
				wave, waveSpeed, waveRangeSize));
		}
	}

	IEnumerator MoveCoroutine (float speed, float angle, float accelSpeed, float accelTurn,
		bool homing, Transform homingTarget, float homingAngleSpeed,
		bool wave, float waveSpeed, float waveRangeSize)
	{

		Vector3 angleVector = Vector3.zero;

		angleVector.Set(transform.eulerAngles.x, transform.eulerAngles.y, angle);


		angleVector.Set(transform.eulerAngles.x, transform.eulerAngles.y, angle);
		transform.eulerAngles = angleVector;


	
		//float selfFrameCnt = 0f;
		//float selfTimeCount = 0f;


		while (true) {
			
				// acceleration turning.
				float addAngle = accelTurn * Time.deltaTime;

				angleVector.Set (angleVector.x, angleVector.y, angleVector.z + addAngle);
			
				transform.eulerAngles = angleVector;
		
			//END OF SPECIFIC BULLETS -----------------------------------------------------------------------
			//STUFF THAT APPLIES TO ALL BULLETS:--------------------------------------------------------------------

			// acceleration speed.
			speed += (accelSpeed * Time.deltaTime);

	
				// X and Y axis
			transform.position += transform.up.normalized * speed * Time.deltaTime;
			transform.eulerAngles.Set(transform.eulerAngles.x, transform.eulerAngles.y , 5.0f);

			yield return 0;

			//TICKS TIME FOR BULLET TIMEOUT ------------------------------------------------
		//	selfTimeCount += Time.deltaTime;

		}
	}

	public int getBulletDamage(){
		return bulletDamage;
	}
}