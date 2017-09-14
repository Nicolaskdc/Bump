using UnityEngine;

public class AffectedByBumpers : MonoBehaviour {

    public float jumpStrengthMultiplier;

    /** Handle collisions with falling objects */
    void OnCollisionEnter(Collision collision) {

        GameObject gameObj = collision.gameObject;
        if (gameObj.tag == "Bumper") {
            
            Destroy(gameObj);
            gameObject.GetComponent<PlayerController>().Jump(jumpStrengthMultiplier);
        }
    }
}
