using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float startingX;
	public float minY;
	public float maxY;

	public float spawnInterval;

	public GameObject bumperPrefab;

    void Start () {
		StartCoroutine (SpawnBumpers ());
	}
	
	IEnumerator SpawnBumpers () {
		while (true) {
            if (GetComponent<RespawnController> ().alive) {
                Vector3 spawnPosition = new Vector3(startingX, Random.value * (maxY - minY) + minY, 0);
                Instantiate(bumperPrefab, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
	}

}
