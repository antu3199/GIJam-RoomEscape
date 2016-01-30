using UnityEngine;
using System.Collections;



public class GuiScript : Singleton<GuiScript>{

	int adjustmentFactorScale = 10;
	float adjustFacPos = 41.6f;

	public void adjustHP(int num){
		float adjust = num / adjustmentFactorScale;

		if (transform.localScale.x - adjust < 0) {
			transform.localScale = new Vector2 (0, 0);
		} else {
			transform.localScale -= new Vector3 (adjust, 0, 0);
			translateHp(num);
		}
	}

	public void translateHp(int num){
		float adjust = num / adjustFacPos;
		transform.position -= new Vector3 (adjust, 0, 0);
	}
}
