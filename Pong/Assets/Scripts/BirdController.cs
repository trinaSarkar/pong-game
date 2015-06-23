using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	private Rigidbody rb; 
	private GameController gameController; 

	public int speed;
	public int secondBallWait; 
	public GameObject ball; 

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("Game Controller");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'Game Controller' script");
		} 

		rb = GetComponent<Rigidbody> ();
		Vector3 movement = new Vector3 (1.0f, 0.0f, 0.0f); 
		rb.velocity = movement * speed; 
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "Hazard") {
			Destroy (gameObject);
			Destroy (other.collider.gameObject); 
		} else if (other.collider.tag == "Right Wall") {
			Destroy (gameObject);
		} else if (other.collider.tag == "Board") {
			return;
		} else if (other.collider.tag == "Ball") {
			gameController.SubtractScore ();
		}
	} 
}
