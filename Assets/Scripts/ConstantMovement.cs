using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour {

	public Vector3 minVelocity;
    public Vector3 maxVelocity;

    void Start () {
        float weightMax = getWeight();
        GetComponent<Rigidbody> ().velocity = minVelocity * (1 - weightMax) + maxVelocity * weightMax;
	}

    /** We want to be biased towards the extremes (0 and 1) */
    float getWeight () {
        float rand = Random.value;
        if (rand <= 0.5f)
            return Random.Range(0f, 0.3f);
        if (rand >= 0.7f)
            return Random.Range(0.8f, 1f);
        return Random.Range(0.2f, 0.8f);
    }
}
