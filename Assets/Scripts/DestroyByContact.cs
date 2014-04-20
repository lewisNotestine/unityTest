using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys the owning object, as well as another object when the owning object's collider collides with it.
/// </summary>
public class DestroyByContact : MonoBehaviour {
	[SerializeField] private GameObject mExplosion;
	[SerializeField] private GameObject mPlayerExplosion; //TODO: should be responsibility of player 
	
	public GameObject explosion {get{return mExplosion;} set{mExplosion = value;}}
	public GameObject playerExplosion {get{return mPlayerExplosion;} set{mPlayerExplosion = value;}}	
	public int scoreValue;
	
	private GameController gameController;

	private void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	private void OnTriggerEnter(Collider otherCollider) {
		if (otherCollider.tag == "Boundary") {
			return;
		} 
		Instantiate (explosion, transform.position, transform.rotation);

		//TODO: this should be the responsibility of Player probably.
		if (otherCollider.tag == "Player") {
			Instantiate(playerExplosion, otherCollider.transform.position, otherCollider.transform.rotation);
			gameController.GameOver();
		}
		
		gameController.AddScore(scoreValue);
		Destroy(otherCollider.gameObject);
		Destroy(gameObject);
	}	
}
