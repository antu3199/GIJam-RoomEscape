using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {

	void OnTriggerExit2D (Collider2D col){
		if (col.tag == "Bullet") {
			Destroy (col.gameObject);
		}
	}
}
