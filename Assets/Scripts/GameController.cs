using UnityEngine;
using System.Collections;

/// <summary>
/// Main GameController class for controlling operations between player, hazards, enemies, etc.
/// </summary>
public class GameController : MonoBehaviour {

	//TODO: there has to be a better way than declaring consts?	
	private const string SCORE = "Score: ";
	private const string GAME_OVER = "Game Over!";
	
	private const int START_SCORE = 0;

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	
	private int score;
	
	
	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}
	
	public void GameOver() {
		gameOverText.text = GAME_OVER;
		gameOver = true;
	}	
	
	private void Start() {
		gameOver = false;
		restart = false;
		restartText.text = string.Empty;
		gameOverText.text = string.Empty;
		score = START_SCORE;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}
	
	private void Update() {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		} 
	}
	
	private void UpdateScore() {
		scoreText.text = SCORE + score;
	}

	private IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while (true) {
			
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x) , spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
	
				//Co-routines, operate asynchronously
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
}
