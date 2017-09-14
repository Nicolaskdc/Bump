using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnController : MonoBehaviour
{

	public GameObject scoreTracker;
	public Text clickToPlayText;

    public GameObject playerPrefab;
    public Vector3 playerStartPos;
    public float respawnDelay;

    public bool alive;
    private bool canSpawn;

    void Start()
    {
        alive = false;
        canSpawn = true;
    }

    void Update()
    {
        if (Input.anyKey && canSpawn)
        {
            alive = true;
            canSpawn = false;
            StartGame();
        }
    }

	void StartGame()
    {
        Instantiate(playerPrefab, playerStartPos, Quaternion.identity);
		scoreTracker.GetComponent<ScoreTracker> ().StartScoreTracking ();
		clickToPlayText.enabled = false;
    }

    IEnumerator AllowRespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        canSpawn = true;
    }

    public void Die()
    {
		alive = false;
		scoreTracker.GetComponent<ScoreTracker> ().StopScoreTracking ();
		clickToPlayText.enabled = true;
		StartCoroutine(AllowRespawnAfterDelay());
    }
}
