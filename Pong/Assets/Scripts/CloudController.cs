using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	private Rigidbody rb;
	private float velocity;

	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); 
		rb.velocity = (new Vector3(0.0f,0.0f,1.0f) * speed); 
	}

	void OnCollisionEnter(Collision other) {
		if (other.collider.tag != "Board") {
			Destroy (gameObject); 
		}
	}
}
