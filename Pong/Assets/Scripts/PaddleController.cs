using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {

		Destroy (gameObject); 
	}
}
