using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys a the parent GameObject after a time.
/// </summary>
public class DestroyByTime : MonoBehaviour {
	
	/// <summary>
	/// The life time in seconds for the GameObject.
	/// </summary>
	public float lifeTime;

	private void Start() {
		Destroy(gameObject, lifeTime);
	}
}
