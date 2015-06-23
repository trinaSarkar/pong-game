using UnityEngine;
using System.Collections;

public class PenguinController : MonoBehaviour {
	 
	void Start() {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); 
	}

	void onCollisionEnter(Collision other) {
		if (other.collider.tag == "Hazard") {
			Destroy (gameObject);
		}
	}
}
