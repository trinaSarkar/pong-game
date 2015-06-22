using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class GameController : MonoBehaviour {

	private int score;
	private bool gameOver; 
	private bool restart;

	public Text scoreText;
	public Text gameOverText;
	public Text welcomeText;
	public Text restartText;

	public int startWait;
	public int hazardCount;
	public int birdCount; 
	public int hazardWait; 
	public int waveWait; 
	public GameObject hazard; 
	public GameObject hazard2;

	void Start () {
		score = 0;
		gameOver = false;  
		restart = false; 
		gameOverText.text = ""; 
		restartText.text = ""; 
		UpdateScore (); 
		welcomeText.text = "WELCOME TO KADHO PONG!";  
		StartCoroutine (SpawnWaves ());
		StartCoroutine (BirdWaves ());
	}

	void Update() {
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) {				
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < hazardCount; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-4.0f, 4.0f), 
			                                     0.0f,
			                                     Random.Range (-2.0f, 4.0f)); 
			Instantiate (hazard, spawnPosition, hazard.transform.rotation); 
			yield return new WaitForSeconds (hazardWait); 
		}
		yield return new WaitForSeconds (waveWait); 
	}

	IEnumerator BirdWaves() {
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < birdCount; i++) {
			Vector3 hazard2Position = new Vector3 (-4.0f, 
			                                       0.0f,	
			                                      Random.Range (-2.0f, 4.0f)); 
			Instantiate (hazard2, hazard2Position, hazard2.transform.rotation); 
			Rigidbody rb2 = hazard2.GetComponent<Rigidbody> ();
			yield return new WaitForSeconds (hazardWait); 
		}
		yield return new WaitForSeconds (waveWait); 
	}

	public void AddScore() {
		score += 1;
		UpdateScore ();
	}

	public void SubtractScore() {
		if (score > 0) { 
			score -= 1;
		}
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score; 	
	}

	public void UpdateGameStatus() {
		gameOver = true; 
		gameOverText.text = "GAME OVER";
		restart = true;
		restartText.text = "Press 'R' to restart"; 
	}
	
}
