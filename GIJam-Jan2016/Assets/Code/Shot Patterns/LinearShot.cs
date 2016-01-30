using UnityEngine;
using System.Collections;

/// <summary>
/// Ubh spiral shot.
/// </summary>
[AddComponentMenu("UniBulletHell/Shot Pattern/Linear Shot")]
public class LinearShot : BulletBehaviour
{
	// "Set a angle of shot. (0 to 360)"
	[Range(0f, 360f)]
	public float _Angle = 180f;
	// "Set a delay time between bullet and next bullet. (sec)"
	public float _BetweenDelay = 0.1f;


	public GameObject _BPrefab; 

	void Update(){


	}

	protected override void Awake ()
	{
		base.Awake();
	}

	public override void Shot ()
	{
	//	Debug.Log ("Linear Shot Coroutine called");

		StartCoroutine(ShotCoroutine());
	}

	IEnumerator ShotCoroutine ()
	{
		//Debug.Log ("test1");
		if (_BulletNum <= 0 || _BulletSpeed <= 0f) {
			Debug.LogWarning("Cannot shot because BulletNum or BulletSpeed is not set.");
			yield break;
		}
		if (_isShooting) {
			yield break;
		}
		_isShooting = true;

		//Debug.Log ("test2");
		for (int i = 0; i < _BulletNum; i++) {
			if (0 < i && 0f < _BetweenDelay) {
				yield return new WaitForSeconds (_BetweenDelay);
			}

			BulletObject bullet = GetBullet(_BulletPrefab, transform.position, transform.rotation);


			if (bullet == null) {
				Debug.Log ("Bullet is NULL");
				break;
			}
		
			//Uses the function in BulletBehaviour to shoot a bullet
			ShotBullet(bullet, _BulletSpeed, _Angle);

		}

		FinishedShot();
	}

}