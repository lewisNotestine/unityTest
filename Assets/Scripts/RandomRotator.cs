using UnityEngine;
using System.Collections;

/// <summary>
/// Makes an object's RigidBody tumble with randomly generated angular velocity. 
/// </summary>
public class RandomRotator : MonoBehaviour {

	private const float DEFAULT_TUMBLE = 1;

	[SerializeField] private float tumble;

	public float Tumble {get{return tumble;} set{tumble = value;}}

	public RandomRotator() {
		Tumble = DEFAULT_TUMBLE;
	}

	private void Start() {
		rigidbody.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
