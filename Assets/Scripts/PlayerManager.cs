using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    GameObject playerGameObject;
    public Vector2 startPosition;

	void Start () {
        playerGameObject = GameObject.FindWithTag(Constants.PLAYER_TAG);
	}

    public void ResetPlayerPosition() {
        playerGameObject.transform.position = startPosition;
    }
}
