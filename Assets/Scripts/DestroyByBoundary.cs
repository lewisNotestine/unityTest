using UnityEngine;
using System.Collections;

/// <summary>
/// Used to destroy a GameObject when it exits the boundary owning this particular script.
/// </summary>
public class DestroyByBoundary : MonoBehaviour {

	private void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}

}
