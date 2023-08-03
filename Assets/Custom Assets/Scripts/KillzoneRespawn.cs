using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneRespawn : MonoBehaviour {

    public GameObject respawnLocation;
    private bool outOfBounds = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && outOfBounds == false) // check if the player has entered this collider
        {
            outOfBounds = true;
            other.transform.position = respawnLocation.transform.position; // teleport the player back to the level start point (We should probably start a fade transition here instead).
            Invoke("Respawned", 1);
        }
    }

    private void Respawned() // This needs a proper check for the player actually 'respawning' correctly.
    {
        outOfBounds = false;
    }

}
