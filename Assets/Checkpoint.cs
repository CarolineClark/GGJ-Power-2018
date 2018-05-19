using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public int level;
    private BoxCollider2D collider2D;
	
    void Start () {
        Debug.Log("Checkpoint script started!");
        collider2D = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag.Equals(Constants.PLAYER_TAG)) {
            LevelEvent.EmitCheckpoint(level);
        }
	}
}
