using UnityEngine;

public class PlayerManager : MonoBehaviour {

    GameObject playerGameObject;
    public Vector2 startPosition;

	void Awake () {
        playerGameObject = GameObject.FindWithTag(Constants.PLAYER_TAG);
	}

    public void ResetPlayerPosition() {
        playerGameObject.transform.position = startPosition;
    }
}
