using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Ubh shot ctrl.
/// </summary>
[AddComponentMenu("UniBulletHell/Controller/Shot Controller")]
public class TurretScript : MonoBehaviour
{
	[Serializable]
	public class ShotInfo
	{
		// "Set a shot pattern component (inherits UbhBaseShot)."
		public BulletBehaviour _ShotObj;
		// "Set a delay time to starting next shot pattern. (sec)"
		public float _AfterDelay;
	}

	public List<Sprite> AnimSprites; 
	public float AnimSpeed = 1;
	// "Axis on bullet move."

	// "This flag starts a shot routine at same time as instantiate."
	public bool _StartOnAwake = true;
	// "Set a delay time at using Start On Awake. (sec)"
	public float _StartOnAwakeDelay = 1f;
	// "This flag repeats a shot routine."
	public bool _Loop = true;
	// "This flag makes a shot routine randomly."
	public bool _AtRandom = false;
	// "List of shot information. this size is necessary at least 1 or more."
	public List<ShotInfo> _bulletList = new List<ShotInfo>();
	bool _Shooting;

	public Transform Player;

	public bool LockonTurret;

	bool isSpawning = false;
	bool isAnim = false;
	float rotationAnim = 0.0f;

	bool ableToShoot = false;

	float directionFrom = 0;
	float animFrames = 0;

	Vector3 initAngleVector = Vector3.zero;

	Vector3 Movement = Vector3.zero;

	SpriteRenderer rend;


	IEnumerator Start ()
	{
		if (_StartOnAwake) {
			if (0f < _StartOnAwakeDelay) {
				yield return new WaitForSeconds (_StartOnAwakeDelay); 
			}
			//NOTE: THIS STARTS SHOOTING ----------------------------------------
			StartShotRoutine();
		}
		rend = GetComponent<SpriteRenderer> ();
	

	}

	void OnDisable ()
	{
		_Shooting = false;
	}
	void Update(){
		
		if (LockonTurret == true) {
			float _Angle = AngleMathFunctions.Instance.GetZangleFromTwoPosition(transform, Player);
			Vector3 angleVector = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, _Angle);
			transform.eulerAngles = angleVector;
		}

		if (isSpawning == true) {
			

			if (directionFrom== 90) {
				Movement.Set (Movement.x, Movement.y - 0.02f, Movement.z);
				transform.position = Movement;
			
			//	transform.position.Set (transform.position.x, transform.position.y - 10.0f, transform.position.z);
			//	transform.position.Set (0.0f, 0.0f, 0.0f);
				Debug.Log (directionFrom);
			}
			if (transform.position.y <= 3.8f) {

		
				isSpawning = false;
				isAnim = true;

			}
		}

		if (isAnim == true) {
			animFrames+= AnimSpeed;

			if (animFrames > 0 && animFrames <= 30) {
				rend.sprite = AnimSprites [0];


			} else if (animFrames > 30 && animFrames <= 60) {
				rend.sprite = AnimSprites [1];
			}
			else if (animFrames > 60 && animFrames <= 90) {
				rend.sprite = AnimSprites [2];
			}
			else if (animFrames > 90 && animFrames <= 120) {
				rend.sprite = AnimSprites [3];
			}
			else if (animFrames > 120 && animFrames <= 150) {
				rend.sprite = AnimSprites [4];
				isAnim = false;
			}

		}
	

	}

	/// <summary>
	/// Start the shot routine.
	/// </summary>
	public void StartShotRoutine ()
	{
		StartCoroutine(ShotCoroutine());
	}

	IEnumerator ShotCoroutine ()
	{

		List<ShotInfo> tmpShotInfoList = new List<ShotInfo>(_bulletList);

		int nowIndex = 0;

		while (true) {
			

			
			if (_AtRandom) {
				nowIndex = UnityEngine.Random.Range(0, tmpShotInfoList.Count);
			}

			if (tmpShotInfoList[nowIndex]._ShotObj != null) {
				tmpShotInfoList[nowIndex]._ShotObj.SetShotCtrl(this);
			
				tmpShotInfoList[nowIndex]._ShotObj.Shot();
			}

			if (0f < tmpShotInfoList[nowIndex]._AfterDelay) {
				yield return new WaitForSeconds (tmpShotInfoList[nowIndex]._AfterDelay); 

			}

			if (_AtRandom) {
				tmpShotInfoList.RemoveAt(nowIndex);

				if (tmpShotInfoList.Count <= 0) {
					if (_Loop) {
						tmpShotInfoList = new List<ShotInfo>(_bulletList);
					} else {
						break;
					}
				}

			} else {
				if (_Loop == false && tmpShotInfoList.Count - 1 <= nowIndex) {
					break;
				}

				nowIndex = (int) Mathf.Repeat(nowIndex + 1f, tmpShotInfoList.Count);
			}

		}

		_Shooting = false;
	}

	/// <summary>
	/// Stop the shot routine.
	/// </summary>
	public void StopShotRoutine ()
	{
		StopAllCoroutines();
		_Shooting = false;
	}

	public void setAnim (bool anim, float direction){
		isSpawning = anim;
		directionFrom = direction;
		//Debug.Log ("setAnim");

		if (directionFrom == 0) {
			initAngleVector = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 270);
			transform.eulerAngles = initAngleVector;
		}
		else if (directionFrom == 90) {
			initAngleVector = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 180);
			transform.eulerAngles = initAngleVector;

		} else if (directionFrom == 180) {
			initAngleVector = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 90);
			transform.eulerAngles = initAngleVector;
		} else if (directionFrom == 270) {
			initAngleVector = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 180);
			transform.eulerAngles = initAngleVector;
		}

		Movement = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}

}