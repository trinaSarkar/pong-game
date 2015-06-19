using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class GameController : MonoBehaviour {

	private int score; 
	private bool gameOver; 

	public Text scoreText;
	public Text gameOverText;
	public Text welcomeText;

	public int startWait;
	public int hazardCount; 
	public int hazardWait; 
	public int waveWait; 
	public GameObject hazard; 

	void Start () {
		score = 0;
		gameOver = false;  
		gameOverText.text = ""; 
		UpdateScore (); 
		welcomeText.text = "WELCOME TO KADHO PONG!"; 
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-4.0f, 4.0f), 
				                                     0.0f,
				                                     Random.Range (-2.0f, 4.0f)); 
				Instantiate (hazard, spawnPosition, hazard.transform.rotation); 
				yield return new WaitForSeconds(hazardWait); 
			}
			yield return new WaitForSeconds(waveWait); 
	}

	public void AddScore() {
		score += 1;
		UpdateScore ();
	}
	
	void UpdateScore () {

		scoreText.text = "Score: " + score; 	
	}

	public void UpdateGameStatus() {
		gameOverText.text = "GAME OVER";
	}
	
}
