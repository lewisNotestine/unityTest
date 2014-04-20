using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys a the parent GameObject after a time.
/// </summary>
public class DestroyByTime : MonoBehaviour {
	
	public float lifeTime;

	private void Start() {
		Destroy(gameObject, lifeTime);
	}
}
