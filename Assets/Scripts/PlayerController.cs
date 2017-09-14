using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpVelocity;
	public float fallMultiplier;

	private Rigidbody rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody> ();
        Jump ();
	}

	void Update () {
		if (Input.anyKeyDown) {
			Jump ();
		}

		// Crisper falling for the jump.
		if (rigidBody.velocity.y < 0) {
			rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
	}

	/** Jumps the character */
	public void Jump(float factor = 1f) {
		// Allow going over the standard jump velocity.
		float newYSpeed = factor * jumpVelocity;
		rigidBody.velocity = new Vector3 (0f, newYSpeed, 0f);
	}
}