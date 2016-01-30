using UnityEngine;
using System.Collections;

/// <summary>
/// Ubh linear lock on shot.
/// </summary>
[AddComponentMenu("UniBulletHell/Shot Pattern/Linear Shot (Lock On)")]
public class LinearShotLockOn : LinearShot
{
	// "Set a target with tag name."
	public bool _SetTargetFromTag = true;
	// "Set a unique tag name of target at using SetTargetFromTag."
	public string _TargetTagName = "Player";
	// "Transform of lock on target."
	// "It is not necessary if you want to specify target in tag."
	// "Overwrite Angle in direction of target to Transform.position."
	public Transform _TargetTransform;
	// "Always aim to target."
	public bool _Aiming;

	protected override void Awake ()
	{
		base.Awake();
	}

	public override void Shot ()
	{

		AimTarget();

		if (_TargetTransform == null) {
			Debug.LogWarning("Cannot shot because TargetTransform is not set.");
			return;
		}

		base.Shot();

		if (_Aiming) {
			StartCoroutine(AimingCoroutine());
		}
	}

	void AimTarget ()
	{
		
		if (_TargetTransform == null && _SetTargetFromTag) {
			

			GameObject goTarget = GameObject.FindWithTag(_TargetTagName);
			_TargetTransform = goTarget.transform;

		}
		if (_TargetTransform != null) {
			
			_Angle = AngleMathFunctions.Instance.GetZangleFromTwoPosition(transform, _TargetTransform);
		}

	}


	IEnumerator AimingCoroutine ()
	{
		while (_Aiming) {


			AimTarget();

			yield return 0;
		}
	}
}