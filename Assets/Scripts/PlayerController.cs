using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	private const float DEFAULT_SPEED = 10;
	[SerializeField] private float speed;
	[SerializeField] private float tilt;
	[SerializeField] private Boundary flightBoundary;

	public float Speed {get{return speed;} set{speed = value;}}
	public float Tilt {get{return tilt;} set{tilt = value;}}
	public Boundary FlightBoundary {get{return flightBoundary;} set{flightBoundary = value;}}
	
	public PlayerController() {
		speed = DEFAULT_SPEED;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <inheritdoc/>
	public void FixedUpdate() {
		float moveHoriz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHoriz, 0.0f, moveVert);
		rigidbody.velocity = movement * Speed;
		rigidbody.position = new Vector3(
			Mathf.Clamp(rigidbody.position.x, FlightBoundary.xMin, FlightBoundary.xMax), 
			0.0f, 
			Mathf.Clamp(rigidbody.position.z, FlightBoundary.zMin, FlightBoundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler( 
			0.0f,
			0.0f,
		    rigidbody.velocity.x * -Tilt
		);
	}


}
