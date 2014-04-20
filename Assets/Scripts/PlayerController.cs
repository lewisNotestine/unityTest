using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	private const float DEFAULT_SPEED = 10;
	private const float DEFAULT_FIRERATE = 0.5f;

	[SerializeField] private float speed;
	[SerializeField] private float tilt;
	[SerializeField] private Boundary flightBoundary;
	[SerializeField] private GameObject shot;
	[SerializeField] private Transform shotSpawn;
	[SerializeField] private float fireRate;
	[SerializeField] private float nextFire;

	//TODO should I even be using these properties? It is great for .NET , but this is not .NET...
	public float Speed {get{return speed;} set{speed = value;}}
	public float Tilt {get{return tilt;} set{tilt = value;}}
	public Boundary FlightBoundary {get{return flightBoundary;} set{flightBoundary = value;}}
	public GameObject Shot {get{return shot;} set{shot = value;}}
	public Transform ShotSpawn {get{return shotSpawn;} set{shotSpawn = value;}}
	public float FireRate {get{return fireRate;} set{fireRate = value;}}

	private float NextFire {get{return nextFire;} set{nextFire = value;}}

	public PlayerController() {
		Speed = DEFAULT_SPEED;
		FireRate = DEFAULT_FIRERATE;
	}

	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetButton("Fire1") && Time.time > NextFire) {
			NextFire = Time.time + FireRate;
			Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
			audio.Play();
		}
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
