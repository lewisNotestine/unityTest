using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private const float DEFAULT_SPEED = 10;

	[SerializeField] private float speed;

	public float Speed{get{return speed;} set{speed = value;}}

	public Mover() {
		Speed = DEFAULT_SPEED;
	}

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * Speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
