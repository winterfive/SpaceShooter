using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {

		if (other.tag == "BoundingBox") {
			return;
		}

		if (other.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
		}

		if (other.tag == "Bolt") {
			Debug.Log (name);
		}

		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
