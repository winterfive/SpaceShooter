using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	Rigidbody rb;

	public Boundary boundary;
	public float speed;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update() {

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			// play firing audio
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate() {
		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		rb = GetComponent<Rigidbody> ();

		Vector3 movement = new Vector3 (moveHorz, 0.0f, moveVert);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt);
	}
}
