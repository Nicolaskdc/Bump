using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour {

    public GameObject GameController;
    public GameObject playerDeathEffect;

    void OnTriggerExit(Collider other) {
        GameObject g = other.gameObject;
        Destroy(g);
        if (g.tag == "Player") {
            // Death effect.
            Instantiate(playerDeathEffect, g.transform.position, g.transform.rotation);
            // Spawn player after delay.
            GameController.GetComponent<RespawnController> ().Die();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!GameController.GetComponent<RespawnController>().alive)
        {
            GameObject g = other.gameObject;
            Destroy(g);
        }
    }
}
