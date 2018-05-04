using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController myGameControllerReference;

	void Start() {

		// Each instance of Asteroid will need its own reference to the GameController script
		// Asteroid instance gets a reference -> GameController Component on GameController object
		
		// Find the thing we will point at
		// Find the object that holds the GameController script via it's tag
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		// Did we find the object tagged GameController?
		if (gameControllerObject != null) {
			// Set the reference to the GameController Component (script)
			// found on the GameController object in the scene
			myGameControllerReference = gameControllerObject.GetComponent <GameController> ();
		}

		// Insurance policy code
		if (myGameControllerReference == null) {
			Debug.Log ("Cannot find GameController script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			myGameControllerReference.GameIsOver ();
		}

		if (other.CompareTag ("Bolt"))
		{
			myGameControllerReference.AddScore (scoreValue);
		}
		
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
