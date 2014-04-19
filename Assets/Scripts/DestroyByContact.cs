using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys the owning object, as well as another object when the owning object's collider collides with it.
/// </summary>
public class DestroyByContact : MonoBehaviour {
	private void OnTriggerEnter(Collider otherCollider) {
		if(otherCollider.tag == "Boundary") {
			return;
		}

		Destroy(otherCollider.gameObject);
		Destroy(gameObject);
	}	
}
