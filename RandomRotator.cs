using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float min, max;
	Rigidbody rb;

	private float tumble;

	void Awake() {
		tumble = Random.Range(min, max);
	}

	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
