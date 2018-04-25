using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float boltSpeed;		// fixed speed for shots
	public float min, max;

	Rigidbody rb;

	private float asteroidSpeed;	// random speed for hazards

	void Awake() {
		// min and max are negative as asteroids need to travel "down"
		asteroidSpeed = Random.Range (-min, -max);
	}

	void Start() {
		Rigidbody rb = GetComponent<Rigidbody>();

		// Asteroid has a random speed
		if (rb.tag == "Asteroid") {
			rb.velocity = transform.forward * asteroidSpeed;
			// TODO Add random direction, change transform.forward
		}

		if (rb.tag == "Bolt") {
			rb.velocity = transform.forward * boltSpeed;
		}
	}
}
