using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	private float min, max;

	void Start() {
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves() {

		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {	
				// Spawn waves of asteroids
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
