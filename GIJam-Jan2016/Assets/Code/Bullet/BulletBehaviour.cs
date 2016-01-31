using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Ubh base shot.
/// Each shot pattern classes inherit this class.
/// </summary>
public abstract class BulletBehaviour : Singleton<BulletBehaviour> 
{

	// "Set a bullet prefab for the shot. (ex. sprite or model)"
	public GameObject _BulletPrefab;
	// "Set a bullet number of shot."
	public int _BulletNum = 10;
	// "Set a bullet base speed of shot."
	public float _BulletSpeed = 2f;
	// "Set an acceleration of bullet speed."
	public float _AccelerationSpeed = 0f;
	// "Set an acceleration of bullet turning."
	public float _AccelerationTurn = 0f;
	// "This flag is pause and resume bullet at specified time."
	public bool _UsePauseAndResume = false;
	// "Set a time to pause bullet."
	public float _PauseTime = 0f;
	// "Set a time to resume bullet."
	public float _ResumeTime = 0f;
	// "This flag settings pooling bullet GameObject at initial awake."
	public bool _InitialPooling = false;
	// "This flag is automatically release the bullet GameObject at the specified time."
	public bool _UseAutoRelease = false;
	// "Set a time to automatically release after the shot at using UseAutoRelease. (sec)"
	public float _AutoReleaseTime = 10f;
	// "Set a GameObject that receives callback method after shot."
	public GameObject _CallbackReceiver;
	// "Set a name of callback method at using Call Back Receiver."
	public string _CallbackMethod;

	TurretScript _Enemy_Parent;

	GameObject bulletContainer;

	bool FixedAngle = false;
	float AngleChange = 0.0f;



	protected TurretScript  Enemy_Parent
	{
		get
		{
			if (_Enemy_Parent == null) {
				_Enemy_Parent = transform.GetComponentInParent<TurretScript >();
			}
			return _Enemy_Parent;
		}
	}


	protected bool _isShooting;

	/// <summary>
	/// Call from override Awake method in inheriting classes.
	/// Example : protected override void Awake () { base.Awake (); }
	/// </summary>
	protected virtual void Awake ()
	{
		
		//BulletObject bullet = GetBullet(_BulletPrefab, Vector3.zero, Quaternion.identity);
		bulletContainer = GameObject.FindWithTag("bulletsContainer");

	}

	/// <summary>
	/// Call from override OnDisable method in inheriting classes.
	/// Example : protected override void OnDisable () { base.OnDisable (); }
	/// </summary>
	protected virtual void DisableShooting ()
	{
		_isShooting = false;
	}

	/// <summary>
	/// Abstract shot method.
	/// </summary>
	public abstract void Shot ();

	/// <summary>
	/// EnemyScript setter.
	/// </summary>
	public void SetShotCtrl (TurretScript shotCtrl)
	{
		_Enemy_Parent = shotCtrl;
	}

	/// <summary>
	/// Finished shot.
	/// </summary>
	protected void FinishedShot ()
	{
		_isShooting = false;
	}

	/// <summary>
	/// Get BulletClassScript object from object pool.THIS IS WHERE IT IS INSTANTIATED !!!!!!!!!!!!!
	/// </summary>
	protected BulletObject GetBullet (GameObject bulletPrefab, Vector3 position, Quaternion rotation)
	{

		if (GameManager.StopAllBullets == false) {
			GameObject bulletGameObject = (GameObject)Instantiate (bulletPrefab, position, rotation);


			BulletObject bullet = bulletGameObject.GetComponent<BulletObject> ();

			if (bullet == null) {
				bullet = bulletGameObject.AddComponent<BulletObject> ();
			}


			bullet.gameObject.transform.SetParent (bulletContainer.transform);
			return bullet;
		} else {
			return null;
		}
	//	Debug.Log ("Bullet GOT!: "  + bullet);
	
	}

	/// <summary>
	/// Shot BulletClassScript object.
	/// </summary>

	/// <summary>
	/// Shot UbhBullet object.
	/// </summary>
	protected void ShotBullet (BulletObject bullet, float speed, float angle,
		bool homing = false, Transform homingTarget = null, float homingAngleSpeed = 0f,
		bool wave = false, float waveSpeed = 0f, float waveRangeSize = 0f)
	{
		if (GameManager.StopAllBullets == false) {


			if (bullet == null) {
				return;
			}
			float angleShoot = 0.0f;

			if (FixedAngle == true) {

				angleShoot = AngleChange;
			} else {
				angleShoot = angle;
			}


			bullet.Shot (speed, angleShoot, _AccelerationSpeed, _AccelerationTurn,
				homing, homingTarget, homingAngleSpeed,
				wave, waveSpeed, waveRangeSize);

		}
	}

	/// <summary>
	/// Destroys game object-----------------------------------------------------------------
	/// </summary>

	public void setFixedAngle (float angle){
		FixedAngle = true;
		AngleChange = angle;
		

	}


}