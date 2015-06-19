using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed; 
	public GameObject hazard2; 

	private Rigidbody rb; 
	private GameController gameController; 
 

	void Start() {

		GameObject gameControllerObject = GameObject.FindWithTag ("Game Controller");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'Game Controller' script");
		} 

		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "Bottom Wall") {
			Destroy (gameObject); 
			gameController.UpdateGameStatus(); 
		}
		if (other.collider.tag == "Hazard") {
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();
			gameController.AddScore ();
			Destroy (other.collider.gameObject); 
			Instantiate (hazard2, other.gameObject.transform.position, hazard2.transform.rotation);
		}
		if (other.collider.tag == "Cube") {
			return;
		}
	}
}
