using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {

		if (collision.collider.tag == "Ball") {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
}
