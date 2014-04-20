using UnityEngine;
using System.Collections;

/// <summary>
/// Main GameController class for controlling operations between player, hazards, enemies, etc.
/// </summary>
public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	private void Start() {
		StartCoroutine(SpawnWaves());
	}

	private IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while (true) {
			
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x) , spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Debug.Log ("instantiating Hazard: " + i);
				Instantiate(hazard, spawnPosition, spawnRotation);
	
				//Co-routines, operate asynchronously
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
