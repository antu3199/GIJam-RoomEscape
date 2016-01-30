using UnityEngine;
using System.Collections;

public class AngleMathFunctions : Singleton<AngleMathFunctions> {


	public float GetZangleFromTwoPosition (Transform fromTrans, Transform toTrans)
	{
		if (fromTrans == null || toTrans == null) {
			return 0f;
		}
		var xDistance = toTrans.position.x - fromTrans.position.x;
		var yDistance = toTrans.position.y - fromTrans.position.y;
		var angle = Mathf.Atan2(xDistance, yDistance) * Mathf.Rad2Deg;
		angle = -Get360Angle(angle);

		return angle;
	}

	public float Get360Angle (float angle)
	{
		while (angle < 0f) {
			angle += 360f;
		}
		while (360f < angle) {
			angle -= 360f;
		}
		return angle;
	}
}
