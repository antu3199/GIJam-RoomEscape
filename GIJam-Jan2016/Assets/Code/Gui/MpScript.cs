using UnityEngine;
using System.Collections;

public class MpScript : Singleton<MpScript> {

	float adjustmentFactorScale = 1.6f;
	float adjustFacPos = 31.25f;
	float zeroPos = -7.9f;
	float mpScale = 10f;
	float maxMp = 50f;

	public void changeMp(float mp){
		float mpMove = mp / maxMp * mpScale;
		transform.localScale = new Vector3 (mpMove, 1, 1);
		transform.position = new Vector3 (zeroPos + mp / maxMp * adjustmentFactorScale, 4.25f, 0f);
	}
		
		

	/*
	public void adjustMP(float num){
		float adjust = num / adjustmentFactorScale;

		if (transform.localScale.x - adjust < 0) {
			transform.localScale = new Vector2 (0, 0);
		} else {
			transform.localScale -= new Vector3 (adjust, 0, 0);
			translateMp(num);
		}
	}

	public void translateMp(float num){
		float adjust = num / adjustFacPos;
		transform.position -= new Vector3 (adjust, 0, 0);
	}
	public void addMp(float num){
		float adjust = num / adjustmentFactorScale;
		if (transform.localScale.x + adjust > 50) {
			transform.localScale = new Vector2 (10, 0);
		} else {
			transform.localScale += new Vector3 (adjust, 0, 0);
			translateMp (-1 * num);
		}
	}
	*/
}
