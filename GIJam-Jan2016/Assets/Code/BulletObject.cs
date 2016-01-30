using UnityEngine;
using System.Collections;

/// <summary>
/// Ubh bullet.
/// This is the primary physics stuff is in.
/// </summary>
public class BulletObject : MonoBehaviour
{


	/*
	void OnDisable ()
	{
		StopAllCoroutines();
		transform.ResetPosition();
		transform.
		transform.ResetRotation();
		_Shooting = false;
	}
	*/




	/// <summary>
	/// Bullet Shot
	/// </summary>
	/// 
	/// 

	public void Shot (float speed, float angle, float accelSpeed, float accelTurn,
		bool homing, Transform homingTarget, float homingAngleSpeed,
		bool wave, float waveSpeed, float waveRangeSize)
	{

		if (gameObject.activeInHierarchy == false) {
			return;
		}

		StartCoroutine(MoveCoroutine(speed, angle, accelSpeed, accelTurn,
			homing, homingTarget, homingAngleSpeed,
			wave, waveSpeed, waveRangeSize));
	}

	IEnumerator MoveCoroutine (float speed, float angle, float accelSpeed, float accelTurn,
		bool homing, Transform homingTarget, float homingAngleSpeed,
		bool wave, float waveSpeed, float waveRangeSize)
	{

		Vector3 angleVector = Vector3.zero;

		angleVector.Set(transform.eulerAngles.x, transform.eulerAngles.y, angle);


		angleVector.Set(transform.eulerAngles.x, transform.eulerAngles.y, angle);
		transform.eulerAngles = angleVector;


	
		float selfFrameCnt = 0f;
		float selfTimeCount = 0f;


		while (true) {

			//SPECIFIC BULLLETS -----------------------------------------------------------------------------------------------
			//HOMING STUFF -----------------------------------------------------
			if (homing) {
				// homing target.
				/*
				if (homingTarget != null && 0f < homingAngleSpeed) {
					float rotAngle = ControllerScript.GetAngleFromTwoPosition(transform, homingTarget, axisMove);
					float myAngle = 0f;
					if (axisMove == ControllerScript.AXIS.X_AND_Z) {
						// X and Z axis
						myAngle = -transform.eulerAngles.y;
					} else {
						// X and Y axis
						myAngle = transform.eulerAngles.z;
					}
					
					float toAngle = Mathf.MoveTowardsAngle(myAngle, rotAngle, GlobalTimerClass.Instance.DeltaTime * homingAngleSpeed);
					
					if (axisMove == ControllerScript.AXIS.X_AND_Z) {
						// X and Z axis
						transform.SetEulerAnglesY(-toAngle);
					} else {
						// X and Y axis
						transform.SetEulerAnglesZ(toAngle);
					}
				}
				*/
				//END OF HOMING STUFF ------------------------------------------------

			} else if (wave) {

				//SINE WAVE -----------------------------------
				/*
				// acceleration turning.
				angle += (accelTurn * GlobalTimerClass.Instance.DeltaTime);
				// wave.
				if (0f < waveSpeed && 0f < waveRangeSize) {
					float waveAngle = angle + (waveRangeSize / 2f * Mathf.Sin(selfFrameCnt * waveSpeed / 100f));
					if (axisMove == ControllerScript.AXIS.X_AND_Z) {
						// X and Z axis
						transform.SetEulerAnglesY(-waveAngle);
					} else {
						// X and Y axis
						transform.SetEulerAnglesZ(waveAngle);
					}
				}
				selfFrameCnt++;
				*/
				//END OF SINE WAVE
			} else {
				// acceleration turning.
				float addAngle = accelTurn * Time.deltaTime;

				angleVector.Set (angleVector.x, angleVector.y, angleVector.z + addAngle);
			
				transform.eulerAngles = angleVector;
			}
			//END OF SPECIFIC BULLETS -----------------------------------------------------------------------
			//STUFF THAT APPLIES TO ALL BULLETS:--------------------------------------------------------------------

			// acceleration speed.
			speed += (accelSpeed * Time.deltaTime);

	
				// X and Y axis
			transform.position += transform.up.normalized * speed * Time.deltaTime;
			transform.eulerAngles.Set(transform.eulerAngles.x, transform.eulerAngles.y , 5.0f);

			yield return 0;

			//TICKS TIME FOR BULLET TIMEOUT ------------------------------------------------
			selfTimeCount += Time.deltaTime;


	
		}


	}
}